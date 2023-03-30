using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using TostiTime.API.HubConfig;
using TostiTime.Core.Entities;
using TostiTime.Core.Interfaces;
using TostiTime.Data;

var builder = WebApplication.CreateBuilder(args);
var corsPolicy = "CorsPolicy";
var corsSetting = "CORS:FrontEndDev";

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(
    options =>
    {
        options.AddPolicy(
            corsPolicy,
            policyBuilder =>
            {
                policyBuilder
                .WithOrigins(builder.Configuration[corsSetting])
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials();
            });
    }
);

builder.Services.AddDbContext<TostiTimeDb>(
    dbContextOptions => dbContextOptions.UseSqlServer(builder.Configuration.GetConnectionString("TostiTimeDb"))
                                        .EnableSensitiveDataLogging());

builder.Services.AddScoped<IRepository<Office>, GenericRepository<Office>>();
builder.Services.AddScoped<IRepository<Slot>, GenericRepository<Slot>>();
builder.Services.AddScoped<IRepository<Person>, GenericRepository<Person>>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddSignalR();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapHub<OfficeHub>("/api/RefreshOffice");

app.Run();
