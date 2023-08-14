#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Services/Reservation/Reservation.API/Reservation.API.csproj", "Services/Reservation/Reservation.API/"]
COPY ["Services/Reservation/Reservation.Core/Reservation.Core.csproj", "Services/Reservation/Reservation.Core/"]
COPY ["Services/Reservation/Reservation.Common/Reservation.Common.csproj", "Services/Reservation/Reservation.Common/"]
COPY ["Services/Reservation/Reservation.Persistence/Reservation.Persistence.csproj", "Services/Reservation/Reservation.Persistence/"]
RUN dotnet restore "Services/Reservation/Reservation.API/Reservation.API.csproj"
COPY . .
WORKDIR "/src/Services/Reservation/Reservation.API"
RUN dotnet build "Reservation.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Reservation.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Reservation.API.dll"]