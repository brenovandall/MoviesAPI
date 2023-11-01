using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmesAPI.Data;

public class DataMovieContext : DbContext
{
    // ctor of the db connection -- >
    public DataMovieContext(DbContextOptions<DataMovieContext> opts) : base(opts)
    {
            
    }

    // foreign keys n : n relation -- > CINE and MOVIE relationated by SESSION
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // movie id and cine id relations
        modelBuilder.Entity<Session>().HasKey(session => new { session.
            MovieId, session.CineId });

        // cine with session relation
        modelBuilder.Entity<Session>().HasOne(session => session.Cine).
            WithMany(cine => cine.Sessions).HasForeignKey(session => session.CineId);

        // movie with session relation
        modelBuilder.Entity<Session>().HasOne(session => session.Movie).
            WithMany(movie => movie.Sessions).HasForeignKey(session => session.MovieId);

        // turning cascade off
        modelBuilder.Entity<Address>().HasOne(address => address.Cine)
            .WithOne(cine => cine.Address).OnDelete(DeleteBehavior.Restrict);
    }

    // property that will recieve post elements and data -- >
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Cine> Cines { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Session> Sessions { get; set; }

}
