FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
# Klasör ismini tekrarlamadan direkt kopyalýyoruz
COPY ["GymBookingApp.Api.csproj", "./"]
RUN dotnet restore "GymBookingApp.Api.csproj"
COPY . .
RUN dotnet build "GymBookingApp.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GymBookingApp.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GymBookingApp.Api.dll"]