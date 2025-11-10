# --------------------------
# Stage 1: Build
# --------------------------
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copia o arquivo de projeto e restaura dependências
COPY ["SafeCap.csproj", "./"]
RUN dotnet restore "SafeCap.csproj"

# Copia todo o restante do código
COPY . ./

# Build e publish
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false

# --------------------------
# Stage 2: Runtime
# --------------------------
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app

# Copia o build do estágio anterior
COPY --from=build /app/publish ./

# Azure App Service escuta na porta 80
EXPOSE 80

# Define o ponto de entrada da aplicação
ENTRYPOINT ["dotnet", "SafeCap.dll"]
