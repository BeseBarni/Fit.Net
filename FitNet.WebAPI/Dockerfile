# Build stage
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy project files
COPY ["FitNet.WebAPI/FitNet.WebAPI.csproj", "FitNet.WebAPI/"]
COPY ["FitNet.DataAccess/FitNet.DataAccess.csproj", "FitNet.DataAccess/"]
COPY ["FitNet.Domain/FitNet.Domain.csproj", "FitNet.Domain/"]
COPY ["FitNet.Interfaces/FitNet.Interfaces.csproj", "FitNet.Interfaces/"]
COPY ["FitNet.Service/FitNet.Service.csproj", "FitNet.Service/"]
COPY ["FitNet.Contracts/FitNet.Contracts.csproj", "FitNet.Contracts/"]
COPY ["FitNet.Infrastructure/FitNet.Infrastructure.csproj", "FitNet.Infrastructure/"]

# Restore dependencies
RUN dotnet restore "FitNet.WebAPI/FitNet.WebAPI.csproj"

# Copy source code
COPY . .

# Build
WORKDIR "/src/FitNet.WebAPI"
RUN dotnet build "FitNet.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publish
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "FitNet.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app

# Copy published app
COPY --from=publish /app/publish .

# Expose ports
EXPOSE 8080
EXPOSE 8081

# Run application
ENTRYPOINT ["dotnet", "FitNet.WebAPI.dll"]