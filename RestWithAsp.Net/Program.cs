using Microsoft.EntityFrameworkCore;
using RestWithAsp.Net.Business;
using RestWithAsp.Net.Business.Implementations;
using RestWithAsp.Net.Model.Context;
using RestWithAsp.Net.Repository.Generic;
using Microsoft.Net.Http.Headers;
using RestWithAsp.Net.Hypermedia.Filters;
using RestWithAsp.Net.Hypermedia.Enricher;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<RestWithAspDotNetContext>(options => options.UseSqlServer
    (builder.Configuration.GetConnectionString("RestWithAspDotNetDB")
    ?? throw new InvalidOperationException("Connection string 'RestWithDotNetDB' not found")));


builder.Services.AddMvc(options => 
{
    options.RespectBrowserAcceptHeader = true;

    options.FormatterMappings.SetMediaTypeMappingForFormat("xml", MediaTypeHeaderValue.Parse("application/xml"));
    options.FormatterMappings.SetMediaTypeMappingForFormat("json", MediaTypeHeaderValue.Parse("application/json"));
}).AddXmlSerializerFormatters();

var filterOptions = new HyperMediaFilterOptions();
filterOptions.ContentResponseEnricherList.Add(new PersonEnricher());
filterOptions.ContentResponseEnricherList.Add(new BookEnricher());

builder.Services.AddSingleton(filterOptions);


// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<IPersonBusiness, PersonBusinessImplementation>();
builder.Services.AddScoped<IBookBusiness, BookBusinessImplementation>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
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
app.MapControllerRoute("DefaultApi", "{controller=values}/v{version=ApiVersion}/{id?}");

app.Run();