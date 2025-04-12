# Unity the Gateway 🦄

> "One gate to route them all, and through the gateway bind them."
> 

**Unity** is the enchanted entryway to the Bytewood realm. It stands at the boundary, validating every traveler’s token and guiding them toward the correct Byte Beast — all while ensuring the secret paths remain safe from the curious and unworthy.

---

## 🔧 Purpose

- Serve as the **central HTTP entrypoint** to all Bytewood microservices
- Validate and authorize requests using **JWT tokens** from [Authix 🐉](../Authix.Auth)
- Handle **role-based routing** and endpoint protection
- Expose a beautiful **Swagger/OpenAPI** UI for explorers

---

## 🔐 Security

Unity enforces strict access rules:

- ✅ Validates JWTs signed by Authix
- ✅ Applies `[Authorize]` and `[Authorize(Roles = "...")]` attributes
- ✅ Extracts claims: `ClaimTypes.Name`, `ClaimTypes.Role`
- ❌ Denies access to unauthorized wanderers

### Recognized Roles

| Role | Description |
| --- | --- |
| `guardian` | Full access to protected zones 🌲 |
| `scout` | Limited access, for observers 🦊 |
| `wanderer` | Guests — access public endpoints only 🌿 |

---

## 📦 Tech Stack

- **.NET 8** Minimal API style
- **JWT Bearer authentication** via `Microsoft.AspNetCore.Authentication.JwtBearer`
- **Swagger / OpenAPI** with JWT auth flow
- Clean route organization via modular **`Endpoints/`** classes

---

### 🗺️ Routes Overview

| Method | Path | Access | Role Required | Description |
| --- | --- | --- | --- | --- |
| GET | `/` | Public | ❌ | Friendly welcome message |
| GET | `/public-info` | Public | ❌ | Available to all wanderers |
| GET | `/ping` | Public | ❌ | Health check |
| GET | `/protected` | Protected | Any | Echoes current user's name & role |
| GET | `/me` | Protected | Any | Returns authenticated user's identity |
| GET | `/secret-forest` | Protected | `guardian` | Hidden grove for trusted guardians |
| GET | `/scout-hq` | Protected | `scout` | Base for scouting and observation |

🛡️ Unauthorized access returns `401 Unauthorized` or `403 Forbidden`.

---

## 🧩 Project Structure

```
Unity.Gateway/
├── Endpoints/
│   └── CommonEndpoints.cs
│   └── PublicEndpoints.cs
│   └── ProtectedEndpoints.cs
├── Configuration/
│   ├── JwtOptions.cs
└── Program.cs
```

---

## 🔌 Integration Points

- 🔐 **Authix.Auth** – Unity trusts Authix to issue and sign all tokens
- 🐢 **Casha.Cache** – (optional) backend data access
- 🐦 **Tweetle.Messenger** – message routing
- 🦉 **Owla.Observer** – internal health + monitoring

---

## 🧙 Developer Notes

- Uses `.AddAuthentication().AddJwtBearer(...)` in `Program.cs`
- Token claims are parsed using `ClaimTypes.Name` and `ClaimTypes.Role`
- Roles are compared case-insensitively for flexibility
- Routes are modular and composable (ideal for growing APIs)

---

## 🔐 Environment Variables

| Name | Description |
| --- | --- |
| `JWT_SECRET` | Must match the signing key used in Authix |
| `ASPNETCORE_ENVIRONMENT` | Set to `Development` or `Docker` |

### Example

```
JWT_SECRET=ThisIsASuperSecureKeyThatIsDefinitelyLongEnough!123456
```

---

## 🛠 Deployment Notes

- Port: `8080` internally, mapped to `5000` externally (via Docker)
- Use consistent networking (`bytewoodnet`) to reach other services
- Swagger UI available at `/swagger`

---

## 🛣 Roadmap

- [x]  JWT validation + role authorization
- [x]  Modular endpoint layout
- [x]  Swagger integration with JWT flow
- [ ]  Forward original claims to downstream Byte Beasts
- [ ]  Dynamic routing rules per role
- [ ]  Gateway metrics and performance logs

---

> “Behind every protected realm, there must be a gate — and someone wise enough to guard it.”