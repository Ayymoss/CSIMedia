using CSIMedia.Context;
using CSIMedia.Repositories;
using CSIMedia.Services;
using Microsoft.EntityFrameworkCore;

namespace CSIMedia;

public static class Program
{
    public static void Main(string[] args)
    {
        CreateBuilder(args).CreateApp().Run();
    }

    private static WebApplicationBuilder CreateBuilder(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Create DB Context
        builder.Services.AddDbContext<DataContext>(options =>
            options.UseSqlServer("Server=<ADDRESS>;Database=CSIMedia;User Id=sa;Password=<PASSWORD>;TrustServerCertificate=True;"));

        // Add custom services to the container.
        builder.Services.AddControllersWithViews();
        builder.Services.AddScoped<NumberRepository>();
        builder.Services.AddScoped<NumberHandlerService>();

        return builder;
    }

    private static WebApplication CreateApp(this WebApplicationBuilder builder)
    {
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        // Ensure database is on latest migrated
        using (var scope = app.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            var dbContext = services.GetRequiredService<DataContext>();
            dbContext.Database.Migrate();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");

        return app;
    }
}
