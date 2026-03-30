FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

COPY . .
RUN dotnet restore
RUN dotnet publish MyFirstCI.Api/MyFirstCI.Api.csproj -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app

ENV ASPNETCORE_URLS=http://+:8080

COPY --from=build /app/out .

EXPOSE 8080

ENTRYPOINT ["dotnet", "MyFirstCI.Api.dll"]
