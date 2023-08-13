#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Services/Hotel/Hotel.API/Hotel.API.csproj", "Services/Hotel/Hotel.API/"]
COPY ["Services/Hotel/Hotel.Core/Hotel.Core.csproj", "Services/Hotel/Hotel.Core/"]
COPY ["Services/Hotel/Hotel.Common/Hotel.Common.csproj", "Services/Hotel/Hotel.Common/"]
COPY ["Services/Hotel/Hotel.Persistence/Hotel.Persistence.csproj", "Services/Hotel/Hotel.Persistence/"]
RUN dotnet restore "Services/Hotel/Hotel.API/Hotel.API.csproj"
COPY . .
WORKDIR "/src/Services/Hotel/Hotel.API"
RUN dotnet build "Hotel.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Hotel.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Hotel.API.dll"]