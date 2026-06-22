# Multi-stage build for the GtMotive Estimate microservice (Host).
# Stage 1 builds and publishes the Host and its dependencies; stage 2 runs the result.

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /source

# The whole repository is copied because the build settings, the analyzers
# configuration (.editorconfig) and the central package versions live at the
# root and are required to compile under the strict analyzers.
COPY . .

RUN dotnet restore "src/GtMotive.Estimate.Microservice.Host/GtMotive.Estimate.Microservice.Host.csproj"
RUN dotnet publish "src/GtMotive.Estimate.Microservice.Host/GtMotive.Estimate.Microservice.Host.csproj" \
    -c Release -o /app --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=build /app .

# Self-contained demo defaults: HTTP on 8080 and the Development environment, so
# Swagger is enabled and no external configuration (Key Vault, Application
# Insights) is required. Override these for a real deployment.
ENV ASPNETCORE_ENVIRONMENT=Development \
    ASPNETCORE_URLS=http://+:8080

EXPOSE 8080
ENTRYPOINT ["dotnet", "GtMotive.Estimate.Microservice.Host.dll"]
