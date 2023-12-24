using Microsoft.EntityFrameworkCore;
using RestWithAsp.Net.Data;
using RestWithAsp.Net.Business;
using RestWithAsp.Net.Business.Implementations;
using RestWithAsp.Net.Repository;
using RestWithAsp.Net.Repository.Implementations;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<RestWithAspDotNetContext>(options => options.UseSqlServer
    (builder.Configuration.GetConnectionString("RestWithAspDotNetDB")
    ?? throw new InvalidOperationException("Connection string 'RestWithDotNetDB' not found")));

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<IPersonBusiness, PersonBusinessImplementation>();
builder.Services.AddScoped<IPersonRepository, PersonRepositoryImplementation>();
builder.Services.AddScoped<IBookBusiness, BookBusinessImplementation>();
builder.Services.AddScoped<IBookRepository, BookRepositoryImplementation>();
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