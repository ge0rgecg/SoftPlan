FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["CalculaJuros/CalculaJuros.csproj", "CalculaJuros/"]
RUN dotnet restore "CalculaJuros/CalculaJuros.csproj"
COPY . .
WORKDIR "/src/CalculaJuros"
RUN dotnet build "CalculaJuros.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CalculaJuros.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CalculaJuros.dll"]

#
#FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
#WORKDIR /app
#EXPOSE 80
#EXPOSE 443
#
#RUN ["rm", "/etc/localtime"]
#RUN ["ln", "-s", "/usr/share/zoneinfo/America/Sao_Paulo", "/etc/localtime"]
#
#FROM microsoft/dotnet:2.2-sdk AS build
#ARG FEED_URL
#ARG PAT
#WORKDIR /src
#
#COPY ./NuGet.Config /root/.nuget/NuGet/NuGet.Config
#
#RUN wget -qO- https://raw.githubusercontent.com/Microsoft/artifacts-credprovider/master/helpers/installcredprovider.sh | bash
#
#ENV DOTNET_SYSTEM_NET_HTTP_USESOCKETSHTTPHANDLER=0
#
#ENV VSS_NUGET_EXTERNAL_FEED_ENDPOINTS="{\"endpointCredentials\": [{\"endpoint\":\"${FEED_URL}\", \"password\":\"${PAT}\"}, {\"endpoint\":\"https://api.nuget.org/v3/index.json\" }]}"
#
#COPY src/Comissao.API/Comissao.API.csproj src/Comissao.API/
#COPY src/Comissao.IoC/Comissao.IoC.csproj src/Comissao.IoC/
#COPY src/Comissao.WsIntegrations/Comissao.WsIntegrations.csproj src/Comissao.WsIntegrations/
#COPY src/Comissao.BizLogic/Comissao.BizLogic.csproj src/Comissao.BizLogic/
#COPY src/Comissao.DataAccess/Comissao.DataAccess.csproj src/Comissao.DataAccess/
#COPY src/Comissao.DataBase/Comissao.DataBase.csproj src/Comissao.DataBase/
#
#RUN dotnet restore src/Comissao.API/Comissao.API.csproj
#COPY . .
#WORKDIR /src/src/Comissao.API
#RUN dotnet build Comissao.API.csproj -c Release -o /app
#
#FROM build AS publish
#RUN dotnet publish Comissao.API.csproj -c Release -o /app
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app .
#ENTRYPOINT ["dotnet", "Comissao.API.dll"]