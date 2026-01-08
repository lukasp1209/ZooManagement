using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Swashbuckle.AspNetCore.Annotations; // optional für [SwaggerOperation]

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular",
        policy => policy.WithOrigins("http://localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader());
});

// ---------------------------
// Services registrieren
// ---------------------------

// Minimal API Explorer (für Endpunkte)
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddControllers(); // Ermöglicht die Nutzung von [ApiController]


// Swagger / OpenAPI
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new()
    {
        Title = "ZooManagement API",
        Version = "v1",
        Description = "API für die Verwaltung von Tieren im Zoo"
    });
});

// CORS falls benötigt
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// ---------------------------
// Middleware konfigurieren
// ---------------------------

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); // schöne Fehlerseite
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "ZooManagement API V1");
        c.RoutePrefix = string.Empty; // Swagger UI unter root URL
    });
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");

// ---------------------------
// Minimal API Endpoints
// ---------------------------

app.MapGet("/animals", () =>
{
    // Beispiel-Daten
    var animals = new[]
    {
        new { Id = 1, Name = "Lion", Species = "Panthera leo" },
        new { Id = 2, Name = "Tiger", Species = "Panthera tigris" },
        new { Id = 3, Name = "Elephant", Species = "Loxodonta africana" }
    };
    return Results.Ok(animals);
})
.WithName("GetAnimals") // Name des Endpunkts für Swagger
.WithTags("Animals");   // Kategorie im Swagger UI

app.MapPost("/animals", (dynamic newAnimal) =>
    {
        // Hier würdest du die Logik für das Hinzufügen eines Tieres implementieren
        return Results.Created($"/animals/{newAnimal.Id}", newAnimal);
    })
    .WithName("AddAnimal")
    .WithTags("Animals");

// ---------------------------
// App starten
// ---------------------------
app.MapControllers();

app.Run();
