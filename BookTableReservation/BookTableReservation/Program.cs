using Microsoft.EntityFrameworkCore;
using Domain.Data;
using BusinessLayer.Repositories;
using BookTableReservation.Mappings;
using BusinessLayer.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DbProjectContext>(Options => Options.UseSqlServer(builder.Configuration.GetConnectionString("ProjectConnectionString")));

builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<ISeatService , SeatService>();
builder.Services.AddScoped<IBookingService , BookingService>();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
