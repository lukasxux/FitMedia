using FitMediaApp.Application.Infastrucure;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<FitMediaContext>(opt =>
    opt.UseSqlite(builder.Configuration.GetConnectionString("Default")));


// Add services to the container.

builder.Services.AddControllers();

// Der Vue.JS Devserver läuft auf einem anderen Port, deswegen brauchen wir diese Konfiguration
if (builder.Environment.IsDevelopment())
{
    builder.Services.AddCors(options =>
        options.AddDefaultPolicy(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));
}

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    using (var db = scope.ServiceProvider.GetRequiredService<FitMediaContext>())
    {
        if (app.Environment.IsDevelopment())
            db.Database.EnsureDeleted();
        db.Database.EnsureCreated();
        if (app.Environment.IsDevelopment())
            db.Seed();
    }
}

app.UseHttpsRedirection();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseCors();
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Liefert die statischen Dateien, die von VueJS generiert werden, aus.
app.UseStaticFiles();
//Ab hier werden alle calls bearbeitet, die an die Api gehen
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
// Bearbeitet die Routen, für die wir Controller geschrieben haben.
app.MapControllers();
// Wichtig für das clientseitige Routing, damit wir direkt an eine URL in der Client App steuern können.
app.MapFallbackToFile("index.html");
app.Run();
