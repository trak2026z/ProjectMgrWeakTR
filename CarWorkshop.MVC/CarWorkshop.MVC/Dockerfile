# Etap 1: build
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# Instalujemy narzędzia EF (dla migratora, zgodne z .NET 7)
RUN dotnet tool install --global dotnet-ef --version 7.0.20
ENV PATH="$PATH:/root/.dotnet/tools"

# Kopiujemy pliki .csproj i przywracamy zależności
COPY CarWorkshop.MVC/*.sln ./
COPY CarWorkshop.Application/*.csproj CarWorkshop.Application/
COPY CarWorkshop.Domain/*.csproj CarWorkshop.Domain/
COPY CarWorkshop.Infrastructure/*.csproj CarWorkshop.Infrastructure/
COPY CarWorkshop.MVC/*.csproj CarWorkshop.MVC/
RUN dotnet restore CarWorkshop.MVC/CarWorkshop.MVC.csproj

# ✅ Dodajemy paczki do Postgresa
RUN dotnet add CarWorkshop.MVC package Npgsql.EntityFrameworkCore.PostgreSQL --version 7.0.11 \
    && dotnet add CarWorkshop.Infrastructure package Npgsql.EntityFrameworkCore.PostgreSQL --version 7.0.11

# Kopiujemy cały kod i budujemy aplikację
COPY . .
WORKDIR /src/CarWorkshop.MVC
RUN dotnet publish CarWorkshop.MVC.csproj -c Release -o /app/publish


# Etap 2: runtime
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS final
# Instalujemy klienta Postgresa (dla pg_isready)
RUN apt-get update && apt-get install -y postgresql-client && rm -rf /var/lib/apt/lists/*
WORKDIR /app
COPY --from=build /app/publish .

# Uruchamiamy aplikację
ENTRYPOINT ["dotnet", "CarWorkshop.MVC.dll"]
