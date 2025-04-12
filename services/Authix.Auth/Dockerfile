FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY shared/Bytewood.Contracts ./shared/Bytewood.Contracts
COPY services/Authix.Auth/Authix.Auth ./services/Authix.Auth
COPY services/Authix.Auth/Authix.Data ./services/Authix.Data

WORKDIR /src/services/Authix.Auth
RUN dotnet restore Authix.Auth.csproj
RUN dotnet publish Authix.Auth.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "Authix.Auth.dll"]