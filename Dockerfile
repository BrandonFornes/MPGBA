# Etapa 1: Base de ejecución (Runtime)
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Etapa 2: Compilación (SDK)
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copiar los archivos de proyecto (.csproj) manteniendo la estructura
COPY ["Server/AdminHerramientas.Server.csproj", "Server/"]
COPY ["Client/AdminHerramientas.Client.csproj", "Client/"]
COPY ["Shared/AdminHerramientas.Shared.csproj", "Shared/"]

# Restaurar las dependencias de toda la solución
RUN dotnet restore "Server/AdminHerramientas.Server.csproj"

# Copiar el resto del código fuente
COPY . .
WORKDIR "/src/Server"

# Compilar el proyecto Server (esto compilará automáticamente el Client)
RUN dotnet build "AdminHerramientas.Server.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Etapa 3: Publicación
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "AdminHerramientas.Server.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Etapa 4: Imagen Final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AdminHerramientas.Server.dll"]