using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers;


[ApiController]
[Route("[controller]")]
public class SessionController : ControllerBase
{

    private DataMovieContext _context;
    private IMapper _mapper;

    public SessionController(DataMovieContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult CreateASession([FromBody] CreateSessionDto sessionDto)
    {
        Session session = _mapper.Map<Session>(sessionDto);

        _context.Sessions.Add(session);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetSessionById), 
            new { movieid = session.MovieId, cineid = session.CineId }, session);
    }

    [HttpGet]
    public IEnumerable<ReadSessionDto> GetSessions()
    {
        return _mapper.Map<List<ReadSessionDto>>(_context.Sessions.ToList());
    }

    [HttpGet("{movieid}/{cineid}")]
    public IActionResult GetSessionById(int movieid, int cineid)
    {
        var sessions = _context.Sessions.First(x => x.MovieId == movieid
        && x.CineId == cineid);

        if ( sessions  == null )
        {
            return NotFound();
        } else
        {
            return Ok(sessions);
        }
    }
}
