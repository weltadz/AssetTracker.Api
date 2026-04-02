using AssetTracker.Api.Data;
using AssetTracker.Api.Dto.AssetCategoryDto;
using AssetTracker.Api.Dto.AssetLocationDto;
using AssetTracker.Api.GlobalException;
using AssetTracker.Api.Model;
using AssetTracker.Api.Services;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var Asset_Tracker_Db = builder.Configuration.GetConnectionString("Asset_Tracker_Db");

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<AssetDbContext>(options => options.UseSqlServer(Asset_Tracker_Db));
builder.Services.AddScoped<AssetCategoryService>();
builder.Services.AddScoped<AssetLocationService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<ValidateService>();
builder.Services.AddScoped<JwtService>();
builder.Services.AddScoped<LoginService>();

//Authentication Configuration
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("jwtSettings"));

var jwtSettings = builder.Configuration
    .GetSection("jwtSettings")
    .Get<JwtSettings>();

if(jwtSettings == null)
{
    throw new KeyNotFoundException();
}

var key = Encoding.UTF8.GetBytes(jwtSettings.Key);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

}).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;

    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,

        ValidIssuer = jwtSettings.Issuer,
        ValidAudience = jwtSettings.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ClockSkew = TimeSpan.Zero
    };
});


//Fluent Validation
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<CreateAssetCategoryValidation>();
builder.Services.AddValidatorsFromAssemblyContaining<CreateAssetLocationValidation>();

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

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
