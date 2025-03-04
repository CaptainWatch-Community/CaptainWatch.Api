using CaptainWatch.Api.Domain.Interface.Buisiness;
using CaptainWatch.Api.Domain.Interface.Repository;
using CaptainWatch.Api.Middlewares;
using CaptainWatch.Api.Repository.Db.EntityFramework.Objects;
using CaptainWatch.Api.Repository.Db.Lists;
using CaptainWatch.Api.Repository.Db.Movies;
using CaptainWatch.Api.Repository.Db.Series;
using CaptainWatch.Api.Repository.Db.Users;
using CaptainWatch.Api.Repository.Meilisearch.Searchs;
using CaptainWatch.Api.Services.Movies;
using CaptainWatch.Api.Services.Series;
using CaptainWatch.Api.Services.Sitemaps;
using ElmahCore;
using ElmahCore.Mvc;
using Meilisearch;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen(options =>
{
    options.EnableAnnotations();
    options.AddSecurityDefinition("Token", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "GUID",
        In = ParameterLocation.Header,
        Description = "Please insert your authorization token as GUID."
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Token"
                }
            },
            new string[] {}
        }
    });
    options.CustomOperationIds(e => $"{e.ActionDescriptor.RouteValues["controller"]}_{e.ActionDescriptor.RouteValues["action"]}");
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "CaptainWatch.Api", Version = "1.0.10" });
});

// Add services to the container.
builder.Services.AddAuthentication("CustomScheme")
    .AddScheme<AuthenticationSchemeOptions, CustomAuthenticationHandler>("CustomScheme", null);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//dependency injection for services
builder.Services.AddScoped<IMovieReadService, MovieReadService>();
builder.Services.AddScoped<ISitemapReadService, SitemapReadService>();
builder.Services.AddScoped<IMovieWriteService, MovieWriteService>();
builder.Services.AddScoped<ISearchWriteService, SearchWriteService>();
builder.Services.AddScoped<ISearchReadService, SearchReadService>();
builder.Services.AddScoped<ISerieWriteService, SerieWriteService>();
builder.Services.AddScoped<IEmailWriteService, EmailWriteService>();

//dependency injection for repositories
builder.Services.AddScoped<IMovieRepo, MovieRepo>();
builder.Services.AddScoped<ISerieRepo, SerieRepo>();
builder.Services.AddScoped<IListRepo, ListRepo>();
builder.Services.AddScoped<ISearchRepo, SearchRepo>();
builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddScoped<IPersonRepo, PersonRepo>();

//dependency injection for meilisearch
var searchmasterKey = builder.Configuration["Search:MasterKey"] ?? throw new Exception("Missing configuration key : Search:MasterKey");
var searchUrl = builder.Configuration["Search:Url"] ?? throw new Exception("Missing configuration key : Search:Url");
builder.Services.AddSingleton(new MeilisearchClient(searchUrl, searchmasterKey));

//dependency injection for db context
builder.Services.AddDbContext<CaptainWatchContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));



//Elmah
builder.Services.AddElmah();

builder.Services.AddElmah<XmlFileErrorLog>(options =>
{
    options.Path = builder.Configuration["Logs:ElmahPath"] ?? throw new Exception("Missing configuration key : Logs:ElmahPath");
    options.LogPath = "~/App_Data";
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthentication();
app.UseAuthorization();

//Elmah
app.UseElmah();

app.MapControllers();

app.Run();
