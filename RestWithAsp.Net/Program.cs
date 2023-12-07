using Microsoft.EntityFrameworkCore;
using RestWithAsp.Net.Data;
using RestWithAsp.Net.Services;
using RestWithAsp.Net.Services.Implementations;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<RestWithAspDotNetContext>(options => options.UseSqlServer
    (builder.Configuration.GetConnectionString("RestWithAspDotNetDB")
    ?? throw new InvalidOperationException("Connection string 'RestWithDotNetDB' not found")));

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<IPersonService, PersonServiceImplementation>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddApiVersioning();
builder.Services.AddSwaggerGen();

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
