# Authix the Gatekeeper 🐉

> "Only those with the true sigil may pass."

**Authix** is the vigilant gatekeeper of Bytewood — issuing signed JWT tokens to magical beings who prove their identity. It guards the border between the public and the protected, ensuring only those with rightful roles may pass through the mists.

---

## 🔧 Purpose

- 🧙‍♀️ Authenticate known Bytewood identities
- 🔐 Issue secure, signed JWT access tokens
- 🔄 Manage and validate refresh tokens
- 🧠 Assign roles via `UserRole` and `ServiceRole` enums
- 🪄 Gracefully handle guests and registered users
- 🧼 Enable internal cleanup of expired tokens
- ❌ Enforce `wanderer` as a non-persistent role

---

## 🧠 Identity Model

Authix uses **Entity Framework Core (SQLite)** for persistence and includes:

### 🧍 Users:

- `Username` (unique)
- `PasswordHash` (BCrypt)
- `Role` (`guardian`, `scout`, `wanderer`)

### 🔐 Service Clients:

- `ClientId`
- `SecretHash` (BCrypt)
- `Role` (`identity`, `observer`, `cache`, etc)

### ♻️ Refresh Tokens:

- Tied to users only
- Expiration tracking
- Marked as used and rotated

> 🪧 The wanderer role is reserved for unauthenticated guests and cannot be stored in the database.

---

## 🔑 Authentication Flow

| Type | Endpoint | Description |
| --- | --- | --- |
| 🧙 Registered | `POST /login` | Authenticate with username + password |
| 🌫️ Guest | `POST /guest?name=...` | Generate short-lived token for wanderers |
| 🤖 Service | `POST /auth/client` | Authenticate services via `client_id` + `secret` |
| ♻️ Refresh | `POST /refresh` | Exchange refresh token for a new access token |

---

## 🔐 Endpoints

| Method | Path | Summary |
| --- | --- | --- |
| `POST` | `/login` | Login with credentials, return JWT + refresh |
| `POST` | `/guest` | Wanderer login without password |
| `POST` | `/refresh` | Exchange valid refresh token |
| `POST` | `/auth/client` | Issue token to known service client |
| `DELETE` | `/tokens/expired` | Delete expired refresh tokens (used by Owla) |

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
pgsql
CopyEdit
Authix.Auth/
├── Configuration/
│   └── JwtOptions.cs
│   └── JwtSettingsProvider.cs
├── Endpoints/
│   ├── LoginEndpoint.cs
│   ├── GuestEndpoint.cs
│   ├── RefreshEndpoint.cs
│   └── DeleteTokenEndpoint.cs
│   └── ClientAuthEndpoint.cs
├── Models/
│   ├── LoginRequest.cs
│   └── RefreshRequest.cs
│   └── ClientAuthRequest.cs
└── Program.cs

Authix.Data/
├── AuthixDbContext.cs
├── AuthixDbContextFactory.cs
├── Models/
│   ├── User.cs
│   └── RefreshToken.cs
│   └── ServiceClient.cs

```

---

## 🧩 Integration Points

| Service | Usage |
| --- | --- |
| 🦄 **Unity.Gateway** | Uses Authix-issued tokens to validate users |
| 🦉 **Owla.Observer** | Logs in as service and calls cleanup APIs |
| 🔮 Other Beasts | Use JWT for scoped communication |

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