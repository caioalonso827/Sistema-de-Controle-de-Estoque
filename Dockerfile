# Etapa base (runtime)
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
USER app
EXPOSE 8080

# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Sistema de Controle de Estoque/Sistema de Controle de Estoque.csproj", "Sistema de Controle de Estoque/"]
RUN dotnet restore "Sistema de Controle de Estoque/Sistema de Controle de Estoque.csproj"
COPY . .
RUN dotnet build "Sistema de Controle de Estoque/Sistema de Controle de Estoque.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Etapa de publish
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Sistema de Controle de Estoque/Sistema de Controle de Estoque.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Etapa final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Sistema de Controle de Estoque.dll", "--urls", "http://+:8080"]