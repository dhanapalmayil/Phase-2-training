using API_Demo.Interface;
using API_Demo.Models;
using API_Demo.Repository;
using API_Demo.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<EmployeeOrgContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("Payoda")));
builder.Services.AddScoped<IEmployee, EmployeeRepo>();
builder.Services.AddScoped<IOrganization, CompanyRepo>();
builder.Services.AddScoped<EmployeeService>();
builder.Services.AddScoped<OrganizationService>();

builder.Services.AddControllers().AddNewtonsoftJson(option =>
{
    option.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});


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
