﻿using FilmesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmesAPI.Data;

public class DataMovieContext : DbContext
{
    // ctor of the db connection -- >
    public DataMovieContext(DbContextOptions<DataMovieContext> opts) : base(opts)
    {
            
    }
    // property that will recieve post elements and data -- >
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Cine> Cines { get; set; }
}
