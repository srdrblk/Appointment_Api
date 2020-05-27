#See htts://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Demo/Demo.csproj", "Demo/"]
COPY ["Models/Models.csproj", "Models/"]
COPY ["./Services/Services.csproj", "./Services/"]
COPY ["./Entities/Entities.csproj", "./Entities/"]
COPY ["./Core/Core.csproj", "./Core/"]
RUN dotnet restore "Demo/Demo.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "Demo/Demo.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Demo/Demo.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Demo.dll"]