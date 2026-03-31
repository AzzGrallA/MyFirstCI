# Этап 1: Сборка
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Копируем только файлы проектов (.csproj) для восстановления зависимостей
COPY MyFirstCI.Api/*.csproj ./MyFirstCI.Api/
COPY MyFirstCI.Tests/*.csproj ./MyFirstCI.Tests/
COPY MyFirstCI.sln .

# Восстанавливаем зависимости
RUN dotnet restore

# Теперь копируем весь остальной код
COPY . .

# Собираем и публикуем приложение
RUN dotnet publish MyFirstCI.Api/MyFirstCI.Api.csproj -c Release -o out

# Этап 2: Финальный образ
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app

ENV ASPNETCORE_URLS=http://+:8080

COPY --from=build /app/out .

EXPOSE 8080

ENTRYPOINT ["dotnet", "MyFirstCI.Api.dll"]
