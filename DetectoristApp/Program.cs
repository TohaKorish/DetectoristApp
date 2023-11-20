using AutoMapper;
using DetectoristApp.BLL.Interfaces.Services;
using DetectoristApp.BLL.Profiles;
using DetectoristApp.BLL.Services;
using DetectoristApp.BLL.Validation;
using DetectoristApp.DAL.Data;
using DetectoristApp.DAL.Data.Repositories;
using DetectoristApp.DAL.Interfaces;
using DetectoristApp.DAL.Interfaces.Repositories;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

var mapperConfig = new MapperConfiguration(cfg =>
{
        cfg.AddProfile(new MapperProfile());
});

IMapper mapper = mapperConfig.CreateMapper();

builder.Services.AddSingleton(mapper);

builder.Services.AddValidatorsFromAssemblyContaining<DetectoristRequestValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<CoilRequestValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<MetaldetectorRequestValidator>();
builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();

builder.Services.AddDbContext<DetectoristDbContext>(
        options => options.UseMySql(connectionString:connectionString,
                serverVersion: ServerVersion.AutoDetect(connectionString))
);

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IDetectoristRepository, DetectoristRepository>();
builder.Services.AddScoped<ICoilRepository, CoilRepository>();
builder.Services.AddScoped<IMetaldetectorRepository, MetaldetectorRepository>();

builder.Services.AddScoped<IDetectoristService, DetectoristService>();
builder.Services.AddScoped<ICoilService, CoilService>();
builder.Services.AddScoped<IMetaldetectorService, MetaldetectorService>();



var app = builder.Build();

app.MapGet("/", () => "Hello World!");

if (app.Environment.IsDevelopment())
{
        app.UseSwagger();
        app.UseSwaggerUI();

}

app.MapControllers();

app.Run();

