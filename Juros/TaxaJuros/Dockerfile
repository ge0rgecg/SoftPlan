FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["TaxaJuros/TaxaJuros.API.csproj", "TaxaJuros/"]
RUN dotnet restore "TaxaJuros/TaxaJuros.API.csproj"
COPY . .
WORKDIR "/src/TaxaJuros"
RUN dotnet build "TaxaJuros.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TaxaJuros.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TaxaJuros.API.dll"]