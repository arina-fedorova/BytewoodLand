FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY shared/Bytewood.Contracts ./shared/Bytewood.Contracts
COPY services/Squee.Scheduler ./services/Squee.Scheduler

WORKDIR /src/services/Squee.Scheduler
RUN dotnet restore Squee.Scheduler/Squee.Scheduler.csproj
RUN dotnet publish Squee.Scheduler/Squee.Scheduler.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "Squee.Scheduler.dll"]