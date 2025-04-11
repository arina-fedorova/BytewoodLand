FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY shared/Bytewood.Contracts ./shared/Bytewood.Contracts
COPY services/Casha.Cache ./services/Casha.Cache

WORKDIR /src/services/Casha.Cache
RUN dotnet restore Casha.Cache/Casha.Cache.csproj
RUN dotnet publish Casha.Cache/Casha.Cache.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "Casha.Cache.dll"]