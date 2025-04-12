# Authix the Gatekeeper 🐉

> "Only those with the true sigil may pass."

**Authix** is the vigilant gatekeeper of Bytewood — issuing signed JWT tokens to magical beings who prove their identity. It guards the borders between the public and the protected, and ensures only those with rightful roles may enter.

---

## 🔧 Purpose

- 🧙‍♀️ Authenticate known Bytewood identities
- 🔐 Issue secure, signed JWT tokens
- 🧠 Assign roles via a central enum (`Role`)
- 🪄 Gracefully handle guests and registered users
- ❌ Prevent unauthorized access via enforced role restrictions

---

## 🧠 Identity Model

Authix uses **Entity Framework Core** with a lightweight SQLite store to maintain known users.

Each user has:

- `Username` (unique identity)
- `Role` (`guardian`, `scout`, `wanderer`)
- `PasswordHash` (BCrypt)

> 🪧 Note: wanderer is a special role, reserved for unregistered users.
> 
> 
> It can’t be assigned to any user in the database.

---

## 🔑 Authentication Flow

| Type | Endpoint | Description |
| --- | --- | --- |
| 🧙 Registered | `POST /login` | Provide username + password to get JWT |
| 🌫️ Guest | `POST /guest?name=` | Generate a short-lived token as a wanderer |

JWTs include standard claims:

```json
{
  "name": "Casha",
  "role": "guardian",
  "iss": "bytewood.authix",
  "aud": "bytewood"
}
```

## 📦 Tech Stack

- [.NET 8](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) Web API
- JWT Bearer Token generation
- Custom `UserStore` and `Role` model
- `ClaimTypes.Name`, `ClaimTypes.Role` used for identity flow
- (Planned) IdentityServer4 or Duende integration

---

## 🔐 Endpoints

| Method | Endpoint | Description |
| --- | --- | --- |
| POST | `/token` | Issues a JWT for a known user |

✅ Currently token exchange is simplified to `?username=...` query for demonstration.

Future versions will support secure login via password and/or external identity.

---

## 🧩 Integration Points

- ✅ **Unity.Gateway** validates tokens and routes by role
- ✅ Other Byte Beasts may rely on claims to forward user context

---

## 🚧 Roadmap

- [ ]  Move `UserStore` to persistent database (EF Core or Redis)
- [ ]  Add `/login` endpoint with password
- [ ]  Integrate with IdentityServer / OAuth2 flows
- [ ]  Add refresh token support and token lifetime management

## 📦 Tech Stack

- **.NET 8** Web API
- **JWT Bearer tokens**
- **Entity Framework Core (SQLite)**
- **BCrypt.Net** for password hashing
- Auto-generated **JWT** via `JwtSecurityTokenHandler`

---

## 📁 Project Structure

```
pgsql
CopyEdit
Authix.Auth/
├── Configuration/
│   └── JwtOptions.cs
├── Endpoints/
│   ├── LoginEndpoint.cs
│   └── GuestEndpoint.cs
├── Models/
│   ├── LoginRequest.cs
└── Program.cs

```

EF Core context and seeding is extracted into a separate project:

```
pgsql
CopyEdit
Authix.Data/
├── AuthixDbContext.cs
├── AuthixDbContextFactory.cs
├── Role.cs
└── User.cs

```

---

## 🧩 Integration Points

- ✅ `Unity.Gateway` uses JWTs issued here for validation
- ✅ Claims like `name` and `role` are used across services
- 🧠 Designed for future expansion into centralized identity

---

## 🚀 Development Notes

- Database file: `data/bytewood_authix.db`
- Container path: `/app/data/bytewood_authix.db` (via volume mount)
- Environment config: `ASPNETCORE_ENVIRONMENT=Docker`

---

## 🔐 Environment Variables

This project uses the following environment variables for JWT authentication:

- `JWT_SECRET` – required by both Authix and Unity to sign/verify tokens

### Example

```python
JWT_SECRET=ThisIsASuperSecureKeyThatIsDefinitelyLongEnough!123456
```

---

## 🔮 Roadmap

- [x]  Migrate `UserStore` to EF Core
- [x]  Add `/login` endpoint with password
- [x]  Enforce `wanderer` role as non-persistent
- [ ]  Refresh token support
- [ ]  Role-based UI for Authix 🐉
- [ ]  Optional IdentityServer integration
- [ ]  Token expiration configuration via settings