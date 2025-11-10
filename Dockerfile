FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY SafeCapAPI.sln ./
COPY SafeCap/SafeCap.csproj SafeCap/
WORKDIR /src/SafeCap
RUN dotnet restore

COPY SafeCap/. ./ 

RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0

#Variavel de ambiente
ENV ASPNETCORE_ENVIRONMENT=Production

RUN useradd -m safecapuser

WORKDIR /app

COPY --from=build /app/publish .

RUN chown -R safecapuser:safecapuser /app

USER safecapuser

EXPOSE 8080

ENTRYPOINT ["dotnet", "SafeCap.dll"]