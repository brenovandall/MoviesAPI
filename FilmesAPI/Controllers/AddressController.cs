using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace FilmesAPI.Controllers;


[ApiController]
[Route("[controller]")]
public class AddressController : ControllerBase
{

    private DataMovieContext _context;
    private IMapper _mapper;

    public AddressController(DataMovieContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult CreateAddress([FromBody] CreateAddressDto addressDto)
    {
        Address address = _mapper.Map<Address>(addressDto);
        
        _context.Addresses.Add(address);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetAddress), new { id = address.Id }, address);
    }

    [HttpGet("{id}")]
    public IActionResult GetAddress(int id)
    {
        var addressvar = _context.Addresses.First(x => x.Id == id);
        if (addressvar == null)
        {
            return NotFound();
        }
        return Ok(addressvar);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateAddress(int id, [FromQuery] UpdateAddressDto update)
    {
        var addressvar = _context.Addresses.FirstOrDefault(x => x.Id == id);
        if (addressvar == null)
        {
            return NotFound();
        }
        _mapper.Map(update, addressvar);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteAddress(int id)
    {
        var addressvar = _context.Addresses.FirstOrDefault(x => x.Id == id);
        if (addressvar == null)
        {
            return NotFound();
        }
        _context.Addresses.Remove(addressvar);
        return NoContent();
    }
}
