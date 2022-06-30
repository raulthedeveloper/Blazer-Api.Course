using LibraryApp.API.Data;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// gets connection string from appsettings.json
var connString = builder.Configuration.GetConnectionString("LibraryDb");

// Adds DbContext to the builder class as a service and is using SQLServer in the options while passing the connection string to it
builder.Services.AddDbContext<LibraryDbContext>(options => options.UseSqlServer(connString));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Used to set up Serilog
builder.Host.UseSerilog((ctx, lc) =>
    lc.WriteTo.Console().ReadFrom.Configuration(ctx.Configuration)
) ;


builder.Services.AddCors( options =>
{
    options.AddPolicy("AllowAll",
     b =>  b.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader() );
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run(); 
