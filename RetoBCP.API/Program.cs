using MediatR;
using Microsoft.EntityFrameworkCore;
using RetoBCP.Application;
using RetoBCP.Application.Query;
using RetoBCP.Domain;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ExchangeRateDbContext>(option => option.UseInMemoryDatabase(builder.Configuration.GetConnectionString("MyDb")));

builder.Services.AddMediatR(typeof(GetAllExchangeRate.Handler).Assembly);
builder.Services.AddAutoMapper(typeof(MappingProfiles).Assembly);


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
