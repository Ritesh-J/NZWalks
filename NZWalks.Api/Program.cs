using Microsoft.EntityFrameworkCore;
using NZWalks.Api.Data;
using NZWalks.Api.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Injection Of DbContextClass 
builder.Services.AddDbContext<NZWalksDbContext>(
    options => options.UseNpgsql(builder.Configuration.GetConnectionString("NZWalksConnectionString")));

//Injection Of IRegionRepository.cs to implement RegionRepositoryImpl.cs
builder.Services.AddScoped<IRegionRepository, RegionRepositoryImpl>();

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
