FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY shared/Bytewood.Contracts ./shared/Bytewood.Contracts
COPY services/Unity.Gateway ./services/Unity.Gateway

WORKDIR /src/services/Unity.Gateway
RUN dotnet restore Unity.Gateway/Unity.Gateway.csproj
RUN dotnet publish Unity.Gateway/Unity.Gateway.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "Unity.Gateway.dll"]
