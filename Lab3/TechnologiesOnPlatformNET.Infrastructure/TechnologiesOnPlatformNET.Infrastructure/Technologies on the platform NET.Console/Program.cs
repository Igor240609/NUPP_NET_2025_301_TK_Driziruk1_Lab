using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TechnologiesOnPlatformNET.Infrastructure.Context;
using TechnologiesOnPlatformNET.Infrastructure.Models;
using TechnologiesOnPlatformNET.Infrastructure.Repositories;
using TechnologiesOnPlatformNET.Infrastructure.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

internal class Program
{
    private static async Task Main(string[] args)
    {
        // Налаштування DI-контейнера
        var services = new ServiceCollection();
        services.AddDbContext<TechnologiesDbContext>(options =>
            options.UseSqlite(@"Data Source=technologies.db"));
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped(typeof(ICrudServiceAsync<>), typeof(CrudServiceAsync<>));

        var serviceProvider = services.BuildServiceProvider();

        using (var scope = serviceProvider.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<TechnologiesDbContext>();
            dbContext.Database.EnsureDeleted(); // Очистити попередню БД, якщо потрібно
            dbContext.Database.EnsureCreated();
        }

        // Отримуємо сервіси
        var dotnetService = serviceProvider.GetRequiredService<ICrudServiceAsync<DotNetTechnologyModel>>();
        var webTechService = serviceProvider.GetRequiredService<ICrudServiceAsync<WebTechnologyModel>>();
        var aspNetService = serviceProvider.GetRequiredService<ICrudServiceAsync<AspNetCoreModel>>();

        // Створюємо об'єкти
        var dotnet = new DotNetTechnologyModel
        {
            Id = Guid.NewGuid(),
            Name = ".NET",
            Version = "8.0"
        };

        var web = new WebTechnologyModel
        {
            Id = Guid.NewGuid(),
            FrontendFramework = "Blazor",
            IsCloudReady = true,
            DotNetTechnologyId = dotnet.Id
        };

        var asp = new AspNetCoreModel
        {
            Id = Guid.NewGuid(),
            Name = "ASP.NET Core",
            Version = "8.0",
            SupportsMinimalAPI = true,
            WebTechnologyId = web.Id,
            
        };

        // Додаємо об'єкти до контексту
        await dotnetService.CreateAsync(dotnet);
        await webTechService.CreateAsync(web);
        await aspNetService.CreateAsync(asp);

        // Зберігаємо всі зміни разом
        await dotnetService.SaveAsync();

        // 4. Read All
        Console.WriteLine("\nAll ASP.NET Core records:");
        var all = await aspNetService.ReadAllAsync();
        foreach (var tech in all)
        {
            Console.WriteLine($"{tech.Id}: {tech.Name} v{tech.Version}");
        }

        // 5. Update
        var first = all.FirstOrDefault();
        if (first != null)
        {
            first.Version = "8.0.1";
            Console.WriteLine("\nUpdating first ASP.NET Core record...");
            await aspNetService.UpdateAsync(first);
            await aspNetService.SaveAsync();
        }

        // 6. Read by ID
        if (first != null)
        {
            var read = await aspNetService.ReadAsync(first.Id);
            Console.WriteLine($"\nRead by ID: {read?.Name} v{read?.Version}");
        }

        // 7. Delete
        if (first != null)
        {
            Console.WriteLine("\nDeleting first ASP.NET Core record...");
            await aspNetService.RemoveAsync(first);
            await aspNetService.SaveAsync();
        }

        // 8. Read All Again
        Console.WriteLine("\nRemaining ASP.NET Core records:");
        var remaining = await aspNetService.ReadAllAsync();
        foreach (var tech in remaining)
        {
            Console.WriteLine($"{tech.Name} v{tech.Version}");
        }

        Console.WriteLine("\nDone.");
    }
}
