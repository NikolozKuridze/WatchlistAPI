using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Watchlist.API.Validators;
using Watchlist.Domain.Interfaces;
using Watchlist.Infrastructure;
using Watchlist.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .Build();

builder.Services.AddSingleton(configuration);
builder.Services.AddDbContext<WatchListDbContext>(options =>
options.UseSqlServer(configuration.GetConnectionString("AppDbConnectionString"),b=>b.MigrationsAssembly("Watchlist.Infrastructure"))); 
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
builder.Services.AddValidatorsFromAssemblyContaining<WatchlistItemValidator>();

builder.Services.AddScoped<IWatchlistRepository, WatchlistRepository>(); 
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddControllers(); 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); 

var app = builder.Build();

// Configure the HTTP request pipeline. 
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "WatchList API V1");
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
