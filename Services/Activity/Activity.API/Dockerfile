#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Services/Activity/Activity.API/Activity.API.csproj", "Services/Activity/Activity.API/"]
COPY ["Services/Activity/Activity.Core/Activity.Core.csproj", "Services/Activity/Activity.Core/"]
COPY ["Services/Activity/Activity.Common/Activity.Common.csproj", "Services/Activity/Activity.Common/"]
COPY ["Services/Activity/Activity.Persistence/Activity.Persistence.csproj", "Services/Activity/Activity.Persistence/"]
RUN dotnet restore "Services/Activity/Activity.API/Activity.API.csproj"
COPY . .
WORKDIR "/src/Services/Activity/Activity.API"
RUN dotnet build "Activity.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Activity.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Activity.API.dll"]