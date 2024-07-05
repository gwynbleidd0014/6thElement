# ბაზისური იმიჯი .NET 8.0-სთვის
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

# ბილდის იმიჯი
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["server/6thElement/6thElement.API/6thElement.API.csproj", "6thElement.API/"]
COPY ["server/6thElement/6thElement.Application/6thElement.Application.csproj", "6thElement.Application/"]
COPY ["server/6thElement/6thElement.Domain/6thElement.Domain.csproj", "6thElement.Domain/"]
COPY ["server/6thElement/6thElement.Infrastructure/6thElement.Infrastructure.csproj", "6thElement.Infrastructure/"]
COPY ["server/6thElement/6thElement.Persistance/6thElement.Persistance.csproj", "6thElement.Persistance/"]
RUN dotnet restore "6thElement.API/6thElement.API.csproj"
COPY server/6thElement .
WORKDIR "/src/6thElement.API"
RUN dotnet build "6thElement.API.csproj" -c Release -o /app/build

# პუბლიკაციის იმიჯი
FROM build AS publish
RUN dotnet publish "6thElement.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

# საბოლოო იმიჯი
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "6thElement.API.dll"]