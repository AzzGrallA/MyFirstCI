using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Добавляем контроллеры
builder.Services.AddControllers();

// Получаем информацию об окружении
var environment = builder.Environment.EnvironmentName;
var configuration = builder.Configuration;

// Читаем настройки из appsettings.{Environment}.json
var appSettings = configuration.GetSection("AppSettings").Get<AppSettings>();

// Выводим в лог информацию о запуске
Console.WriteLine("=========================================");
Console.WriteLine($"Приложение запущено в режиме: {environment}");
Console.WriteLine($"Сообщение: {appSettings?.WelcomeMessage ?? "Сообщение не найдено"}");
Console.WriteLine("=========================================");

var app = builder.Build();

app.UseHttpsRedirection();
app.MapControllers();

app.Run();

// Класс для чтения настроек
public class AppSettings
{
    public string EnvironmentName { get; set; }
    public string WelcomeMessage { get; set; }
}