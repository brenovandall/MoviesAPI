using FilmesAPI.Data;
using FilmesAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddControllers().AddJsonOptions(x =>
//   x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);

// Add services to the container.
builder.Services.AddDbContext<DataMovieContext>(opts => opts.UseLazyLoadingProxies().
    UseMySql(builder.Configuration.GetConnectionString("MovieConnection"),
    ServerVersion.AutoDetect(builder.Configuration.
    GetConnectionString("MovieConnection"))));

// mapper instance -- >
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();





