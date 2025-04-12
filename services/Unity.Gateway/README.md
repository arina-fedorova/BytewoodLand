# Unity the Gateway 🦄

> "One gate to route them all, and through the gateway bind them."

**Unity** is the enchanted entrance to the realm of Bytewood. She stands watch at the forest’s edge, guarding access and guiding each request to the right magical service deep within the woods.

Unity handles:

- 💡 JWT validation
- 🔁 Role-based routing
- 🌐 Service abstraction
- 📜 OpenAPI docs for the outside world

---

## 🔧 Purpose

- Serve as the **central HTTP entrypoint** to all Byte Beasts
- Validate and authorize users via **JWT tokens**
- Forward requests to microservices (reverse proxy-style or direct call)
- Present clean and complete **API documentation** with Swagger

---

## 🔐 Security

- Validates JWT tokens issued by [Authix 🐉](../Authix.Auth)
- Enforces access via `[Authorize]` and `[Authorize(Roles = "...")]`
- Denies access to unauthorized creatures (403 🛑)
- Recognizes 3 magical roles:
  - `guardian` — full access to protected resources 🌳
  - `scout` — limited access, used for background or event-driven tasks 🦊
  - `wanderer` — unauthenticated traveler, allowed in public only 🌿

---

## 📦 Tech Stack

- [.NET 8](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) Minimal API
- JWT Bearer Authentication
- Clean endpoint modularization (`PublicEndpoints`, `ProtectedEndpoints`, `CommonEndpoints`)
- Swagger/OpenAPI with secured JWT flow

---

## 🗺️ Available Routes

| Method | Endpoint           | Access        | Role Required | Description                              |
|--------|--------------------|---------------|---------------|------------------------------------------|
| GET    | `/`                | Public        | ❌             | Welcome message                          |
| GET    | `/public-info`     | Public        | ❌             | Info for wanderers                       |
| GET    | `/protected`       | Protected     | Any           | Echo role & user info                    |
| GET    | `/secret-forest`   | Protected     | `guardian`    | Private realm for high-trust users       |
| GET    | `/scout-hq`        | Protected     | `scout`       | Internal tools for scouting roles        |
| GET    | `/ping`            | Public        | ❌             | Health check                             |

🛡️ Unauthorized users will receive `403 Forbidden` on protected routes.

---

## 🔌 Dependencies

- 🔐 [Authix.Auth](../Authix.Auth) for JWT validation
- 🐦 Tweetle.Messenger — for event/messaging APIs
- 🐢 Casha.Cache — for data retrieval
- 🧠 Future beasts: event triggers, telemetry, dashboards

---

## 🧩 Extending Unity

- Add new routes in `Endpoints/` by role or concern
- Register route groups via extension methods in `Program.cs`
- Add role policies for multi-role rules
- Forward claims to internal services (coming soon!)

---

## 🧙‍♀️ Developer Notes

- Uses `ClaimTypes.Role` and `ClaimTypes.Name` from validated JWT
- Enforces casing consistency with `RoleNames` helper
- Designed to be small, modular, and easy to test

---

> “Behind every protected realm, there must be a gate — and someone wise enough to guard it.”