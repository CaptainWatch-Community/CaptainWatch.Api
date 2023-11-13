using CaptainWatch.Api.Domain.Interface.Buisiness;
using CaptainWatch.Api.Domain.Interface.Repository;
using CaptainWatch.Api.Repository.Db.Movies;
using CaptainWatch.Api.Services.Movies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//dependency injection for services
builder.Services.AddScoped<IMovieServiceRead, MovieServiceRead>();

//dependency injection for repositories
builder.Services.AddScoped<IMovieRepo, MovieRepo>();

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
