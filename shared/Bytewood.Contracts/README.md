# Bytewood.Contracts

This project contains shared contracts used across all Bytewood microservices:

- **DTOs** – shared data structures passed via HTTP or gRPC
- **Events** – message contracts used with RabbitMQ or other messaging systems

Services **must not** reference each other's internal code directly — all shared types should go here.

## Structure

- `/DTOs` – HTTP/gRPC data contracts
- `/Events` – Messaging contracts (e.g., `UserRegisteredEvent`, etc.)

## Usage

Each service adds a reference to this package:

```bash
dotnet add reference ../../shared/Bytewood.Contracts/Bytewood.Contracts.csproj
```
