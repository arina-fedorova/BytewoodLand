FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY shared/Bytewood.Contracts ./shared/Bytewood.Contracts
COPY services/Tweetle.Messenger ./services/Tweetle.Messenger

WORKDIR /src/services/Tweetle.Messenger
RUN dotnet restore Tweetle.Messenger/Tweetle.Messenger.csproj
RUN dotnet publish Tweetle.Messenger/Tweetle.Messenger.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "Tweetle.Messenger.dll"]