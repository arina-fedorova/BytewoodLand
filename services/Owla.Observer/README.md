# Owla the Observer 🦉

> "I see all. I log all. I remember what others forget."

**Owla** is the ever-watchful sentinel of Bytewood. Perched high in the digital canopy, she listens, records, and alerts — keeping the realm healthy and accountable. Every heartbeat of the system is heard by her wings.

---

🔧 Purpose

- 🩺 **Service observability**
- 🌡️ **Health checks and uptime monitoring**
- 🧹 Automatic cleanup of expired tokens in Authix
- 📓 **Structured logging (planned: external aggregation)**
- 🛎️ **Alert triggers for failure events**
- 🧠 Central logic for future **system telemetry**

---

## 📦 Tech Stack

- **.NET 8** Worker Service
- `HttpClient` + **dependency injection**
- **ILogger** / Serilog (future log pipeline)
- JWT-based auth against **Authix**
- (Planned) **OpenTelemetry**, **Prometheus**, or **ELK**

---

## 📡 What Owla Tracks

| Target | Endpoint | Purpose |
| --- | --- | --- |
| Unity 🦄 | `GET /ping` | Gateway health check |
| Authix 🐉 | `DELETE /tokens/expired` | Cleanup expired refresh tokens |
| 🔮 Future Beasts | – | Metrics, logs, alerts |

---

## 🔄 Current Flow

Every **10 seconds**, Owla:

1. Pings `Unity.Gateway` for availability.
2. Authenticates with `Authix.Auth` via `/auth/client` (service client).
3. Calls `DELETE /tokens/expired` to clear stale refresh tokens.
4. Logs results with structured `ILogger`.

---

## 🧩 Integration Points

- 🦄 **Unity.Gateway** — checked for availability
- 🐉 **Authix.Auth** — service-to-service authentication and token cleanup
- 🧪 Future Byte Beasts — metrics, alerts, trace correlation

---

## ⚙️ Configuration Notes

Owla uses **service client auth**, not user login.

```bash
AUTHIX_URL=http://authix.auth:8080
UNITY_URL=http://unity.gateway:8080

OWLA_CLIENT_ID=owla
OWLA_CLIENT_SECRET=owlasecret
```

Set these via environment variables or secrets provider (Docker, Azure, etc) - TBD.

---

## 🧙 Deployment

- Included in `docker-compose.yml`
- Part of `bytewoodnet` internal network
- Runs continuously as `BackgroundService`

---

## 🔮 Future Roadmap

- [ ]  Centralized structured logging (e.g., Seq or ELK)
- [ ]  Prometheus metrics exporter
- [ ]  Graph-based service uptime dashboard
- [ ]  Alert integration (Slack / Email / PagerDuty)
- [ ]  Automatic retry + alert escalation
- [ ]  Tracing correlation across services (OpenTelemetry)

---

> "Guardians protect, scouts explore… but it’s the observers who remember. That’s what makes Bytewood strong."