FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY shared/Bytewood.Contracts ./shared/Bytewood.Contracts
COPY services/Owla.Observer ./services/Owla.Observer

WORKDIR /src/services/Owla.Observer
RUN dotnet restore Owla.Observer/Owla.Observer.csproj
RUN dotnet publish Owla.Observer/Owla.Observer.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "Owla.Observer.dll"]