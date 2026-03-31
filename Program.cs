using AssetTracker.Api.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var Asset_Tracker_Db = builder.Configuration.GetConnectionString("Asset_Tracker_Db");

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<AssetDbContext>(options => options.UseSqlServer(Asset_Tracker_Db));

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
