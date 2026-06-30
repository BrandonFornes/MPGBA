using AdminHerramientas.Server.Models;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using AdminHerramientas.Server.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddDbContext<AlpContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var logger = services.GetRequiredService<ILogger<Program>>();
    
    // Configuración de reintentos para esperar a SQL Server en Docker
    int retries = 5;
    while (retries > 0)
    {
        try
        {
            var context = services.GetRequiredService<AlpContext>();

            logger.LogInformation("Intentando conectar a la base de datos y aplicar migraciones...");
            context.Database.Migrate(); 
            logger.LogInformation("Pending migrations: " + string.Join(",", context.Database.GetPendingMigrations()));
            logger.LogInformation("Applied migrations: " + string.Join(",", context.Database.GetAppliedMigrations()));
            logger.LogInformation("Inyectando datos semilla (Seed Data)...");
            DbInitializer.Seed(context); 
            
            break; // Si todo sale bien, salimos del bucle
        }
        catch (Exception ex)
        {
            retries--;
            logger.LogWarning($"La base de datos no está lista aún. Reintentando... ({retries} intentos restantes). Error: {ex.Message}");
            
            if (retries == 0)
            {
                logger.LogCritical(ex, "No se pudo establecer conexión con SQL Server después de varios intentos.");
                throw;
            }
            
            // Espera 5 segundos antes de volver a intentar conectar
            System.Threading.Thread.Sleep(5000);
        }
    }
}
app.Run();
