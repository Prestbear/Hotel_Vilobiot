using FluentValidation;
using Hotel_Vilobiot.Data;
using Hotel_Vilobiot.Helpers;
using Hotel_Vilobiot.Models;
using Hotel_Vilobiot.Services.GuestService;
using Hotel_Vilobiot.Services.IGuestService;
using Hotel_Vilobiot.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>();
builder.Services.AddScoped<IGuestService, GuestService>();
builder.Services.AddAutoMapper(cnf => { }, typeof(UserMapper));
builder.Services.AddValidatorsFromAssemblyContaining<RegisterValidator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapSwagger();
    app.MapSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();