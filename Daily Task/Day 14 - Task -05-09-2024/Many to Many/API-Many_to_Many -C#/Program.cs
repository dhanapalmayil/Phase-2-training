using API_Many_to_Many__C_.Interface;
using API_Many_to_Many__C_.Models;
using API_Many_to_Many__C_.Repository;
using API_Many_to_Many__C_.Service;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BookAuthorContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("Payoda")));

builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});

builder.Services.AddScoped<IBook,BookRepo>();
builder.Services.AddScoped<BookService>();

builder.Services.AddScoped<IAuthor, AuthorRepo>();
builder.Services.AddScoped<AuthorService>();

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
