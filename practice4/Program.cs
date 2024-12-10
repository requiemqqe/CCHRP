using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Додаємо підтримку контролерів
        builder.Services.AddControllers();

        // Додаємо Swagger
        builder.Services.AddEndpointsApiExplorer(); // Це для Swagger
        builder.Services.AddSwaggerGen(); // Це для генерації документації Swagger

        var app = builder.Build();

        // Включаємо використання Swagger
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger(); // Генерація Swagger документації
            app.UseSwaggerUI(); // Інтерфейс для тестування API
        }

        // Налаштування маршрутизації
        app.MapControllers();

        // Запуск програми
        app.Run();
    }
}
