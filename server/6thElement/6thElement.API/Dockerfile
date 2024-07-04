# Use the official .NET image as a parent image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5141

# Use the SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy the .csproj files and restore dependencies
COPY ["6thElement/server/6thElement/6thElement.API/6thElement.API.csproj", "6thElement.API/"]
COPY ["6thElement/server/6thElement/6thElement.Application/6thElement.Application.csproj", "6thElement.Application/"]
COPY ["6thElement/server/6thElement/6thElement.Domain/6thElement.Domain.csproj", "6thElement.Domain/"]
COPY ["6thElement/server/6thElement/6thElement.Persistance/6thElement.Persistance.csproj", "6thElement.Persistance/"]

RUN dotnet restore "6thElement.API/6thElement.API.csproj"

# Copy everything else and build
COPY . .
WORKDIR "/src/6thElement/server/6thElement/6thElement.API"
RUN dotnet build "6thElement.API.csproj" -c Release -o /app/build

# Publish the app
FROM build AS publish
RUN dotnet publish "6thElement.API.csproj" -c Release -o /app/publish

# Final stage for the runtime image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "6thElement.API.dll"]
