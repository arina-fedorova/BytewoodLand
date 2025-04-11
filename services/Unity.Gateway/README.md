# Unity the Gateway 🦄

> "One gate to route them all, and through the gateway bind them."

Unity the Gateway is the single entry point into the Bytewood ecosystem. She routes incoming HTTP requests to the correct Byte Beasts, validates tokens, and hides internal service complexity from the outside world.

## 🔧 Purpose

- Serves as API Gateway (reverse proxy-style)
- Routes requests to microservices (via REST, gRPC, etc.)
- Handles authentication (JWT validation)
- Exposes OpenAPI documentation

## 📦 Tech Stack

- .NET 8 Minimal API
- JWT Bearer authentication
- Reverse proxy-style service routing
- Swagger/OpenAPI

## 🗺️ Routes

| Endpoint | Forwards to | Notes |
|---------|-------------|-------|
| `/api/messages` | Tweetle.Messenger | Message sending |
| `/api/cache`    | Casha.Cache       | Cached data access |
| ...             | ...               | More as system grows |

## 🧩 Dependencies

- [Authix.Auth](../Authix.Auth) for JWT validation
- Other Byte Beasts via HTTP or message bus

## 🔒 Security

This service **requires JWT** tokens for access to most endpoints.