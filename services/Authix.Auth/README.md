# Authix the Gatekeeper 🐉

> "Only those with the true sigil may pass."

**Authix** is the gatekeeper of Bytewood — issuing signed JWT tokens to verified magical beings. It controls who may enter the protected paths, who watches from afar, and who must remain a wanderer.

---

## 🔧 Purpose

- 🧙‍♀️ Authenticate known Bytewood identities
- 🔐 Issue JWT tokens with assigned roles
- 🧠 Handle internal role mapping via enum
- ❌ Prevent unauthorized role claims (e.g. wanderers can't be registered)

---

## 🧠 Identity Model

Authix maintains an **in-memory `UserStore`** of trusted beings — each with:

- A unique name
- A predefined role:
    - `guardian` – protectors of secrets
    - `scout` – event listeners and messengers
    - `wanderer` – reserved for unauthenticated users only (never assigned)

🔐 All JWTs are signed with a shared key and include standard claims like:

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