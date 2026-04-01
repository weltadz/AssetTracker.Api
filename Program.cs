using AssetTracker.Api.Data;
using AssetTracker.Api.Dto.AssetCategoryDto;
using AssetTracker.Api.GlobalException;
using AssetTracker.Api.Services;
using AssetTracker.Api.Services.Interfaces;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var Asset_Tracker_Db = builder.Configuration.GetConnectionString("Asset_Tracker_Db");

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<AssetDbContext>(options => options.UseSqlServer(Asset_Tracker_Db));
builder.Services.AddScoped<IAssetCategoryService, AssetCategoryService>();
builder.Services.AddScoped<IAssetLocationService, AssetLocationService>();

//Fluent Validation
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<CreateAssetCategoryValidation>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure the HTTP request pipeline.
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<GlobalExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
