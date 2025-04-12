# Authix the Gatekeeper 🐉

> "Only those with the true sigil may pass."

**Authix** is the vigilant gatekeeper of Bytewood — issuing signed JWT tokens to magical beings who prove their identity. It guards the border between the public and the protected, ensuring only those with rightful roles may pass through the mists.

---

## 🔧 Purpose

- 🧙‍♀️ Authenticate known Bytewood identities
- 🔐 Issue secure, signed JWT access tokens
- 🔄 Manage and validate refresh tokens
- 🧠 Assign roles via a central enum (`Role`)
- 🪄 Gracefully handle guests and registered users
- ❌ Enforce `wanderer` as a non-persistent role

---

## 🧠 Identity Model

Authix uses **Entity Framework Core (SQLite)** for persistence and includes:

- `User` with:
    - `Username` (unique)
    - `Role` (`guardian`, `scout`, `wanderer`)
    - `PasswordHash` (BCrypt)
- `RefreshToken` with expiration, usage flag, and user linkage

> 🔒 wanderer is a reserved role and can’t be stored in the database.

---

## 🔑 Authentication Flow

| Type | Endpoint | Description |
| --- | --- | --- |
| 🧙‍♀️ Registered | `POST /login` | Authenticate with username + password |
| 🌫️ Guest | `POST /guest?name=...` | Generate short-lived token for wanderers |
| ♻️ Refresh | `POST /refresh` | Exchange refresh token for a new access token |

All JWTs include standard claims:

```json
{
  "name": "Casha",
  "role": "guardian",
  "iss": "bytewood.authix",
  "aud": "bytewood"
}

```

## 🔐 Endpoints

| Method | Path | Purpose |
| --- | --- | --- |
| `POST` | `/login` | Login with password, receive JWT + refresh |
| `POST` | `/guest` | Anonymous token for wanderers |
| `POST` | `/refresh` | Exchange refresh token |
| `DELETE` | `/tokens/expired` | Cleanup expired or used tokens *(internal)* |

---

## 📦 Tech Stack

- **.NET 8** Web API (Minimal API style)
- **Entity Framework Core** with SQLite
- **BCrypt.Net** for secure password hashing
- **JWT Bearer** token generation and validation
- 🔜 *Optional*: IdentityServer / Duende (planned)

---

## 📁 Project Structure

```
Authix.Auth/
├── Configuration/
│   └── JwtOptions.cs
│   └── JwtSettingsProvider.cs
├── Endpoints/
│   ├── LoginEndpoint.cs
│   ├── GuestEndpoint.cs
│   ├── RefreshEndpoint.cs
│   └── DeleteTokenEndpoint.cs
├── Models/
│   ├── LoginRequest.cs
│   └── RefreshRequest.cs
└── Program.cs

Authix.Data/
├── AuthixDbContext.cs
├── AuthixDbContextFactory.cs
├── Models/
│   ├── Role.cs
│   ├── User.cs
│   └── RefreshToken.cs

```

---

## 🌐 Integration Points

- ✅ **Unity.Gateway** validates and authorizes requests using tokens issued by Authix
- ✅ **Owla.Observer** logs in automatically and cleans up expired tokens via internal APIs

---

## ⚙️ Environment Setup

Authix expects certain environment variables to be present:

| Variable | Purpose |
| --- | --- |
| `JWT_SECRET` | Used to sign access tokens |
| `ASPNETCORE_ENVIRONMENT` | Set to `Docker` inside container |
| Volume | `/app/data` folder is mounted to host for DB persistence |

### Example `docker-compose.yml` snippet:

```yaml
authix.auth:
  build:
    context: .
    dockerfile: services/Authix.Auth/Dockerfile
  ports:
    - "5001:8080"
  volumes:
    - ./data:/app/data
  environment:
    - ASPNETCORE_ENVIRONMENT=Docker
    - JWT_SECRET=ThisIsASuperSecureKeyThatIsDefinitelyLongEnough!123456

```

---

## 📂 Data Location

- 🗃 Local DB: `./data/bytewood_authix.db`
- 🐳 Inside Docker: `/app/data/bytewood_authix.db`

---

## 🛣 Roadmap

- [x]  Migrate `UserStore` to EF Core
- [x]  Add secure `/login` endpoint
- [x]  Implement refresh token flow
- [x]  Auto-cleanup expired tokens via **Owla**
- [ ]  Token expiration settings in config
- [ ]  Role-based UI or Swagger plugin
- [ ]  IdentityServer integration

---

## 🧙 Summary

Authix ensures Bytewood remains a protected realm of structured access and graceful authentication. Whether you're a guardian of secrets or a passing wanderer, your journey starts here — with the sigil of trust.