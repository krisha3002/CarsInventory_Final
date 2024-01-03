// CarsInventoryMvc/Startup.cs

using System.Reflection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

public class Startup
{
    // ...

    public void ConfigureServices(IServiceCollection services)
    {
        // ...
        services.AddScoped<IUnitOfWork, UnitOfWork>();


        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Cars Inventory API", Version = "v1" });

            // Optional: Set the comments path for the Swagger JSON and UI.
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            c.IncludeXmlComments(xmlPath);
        });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        // ...

        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Cars Inventory API V1");
            // Uncomment the next line if you want Swagger UI at the app's root
            // c.RoutePrefix = string.Empty;
        });

        // ...
    }
}
