# Authix the Gatekeeper 🐉

> "Only those with the true sigil may pass."

Authix is the guardian of the forest, issuing JWT tokens to verified users, systems, and trusted beasts. He ensures only approved identities gain access to protected Bytewood services.

## 🔧 Purpose

- User and service authentication
- Issues signed JWTs with proper claims
- Handles login/token exchange
- (Optional later: client credentials flow, refresh tokens)

## 📦 Tech Stack

- .NET 8 Web API
- IdentityServer / Duende (future)
- JWT Bearer token issuance

## 🧩 Integration Points

- Unity.Gateway for authentication
- Other services that consume/validate JWT

## 🔐 Endpoints

| Method | Endpoint     | Description        |
|--------|--------------|--------------------|
| POST   | `/token`     | Get a JWT token    |
| POST   | `/login`     | Authenticate user  |

## 🚧 Notes

- This service is planned to grow into full IdentityServer integration.