#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["CalculaJuros/CalculaJuros.API.csproj", "CalculaJuros/"]
COPY ["CalculaJuros.Integration/CalculaJuros.Integration.csproj", "CalculaJuros.Integration/"]
COPY ["CalculaJuros.Service/CalculaJuros.Service.csproj", "CalculaJuros.Service/"]
RUN dotnet restore "CalculaJuros/CalculaJuros.API.csproj"
COPY . .
WORKDIR "/src/CalculaJuros"
RUN dotnet build "CalculaJuros.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CalculaJuros.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CalculaJuros.API.dll"]