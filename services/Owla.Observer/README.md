# Owla the Observer 🦉

> "I see all. I log all. I remember what others forget."

**Owla** is the ever-watchful sentinel of Bytewood. Perched high in the digital canopy, she listens, records, and alerts — keeping the realm healthy and accountable. Every heartbeat of the system is heard by her wings.

---

🔧 Purpose

- 🩺 **Service observability**
- 🌡️ **Health checks and uptime monitoring**
- 📓 **Structured logging (planned: external aggregation)**
- 🛎️ **Alert triggers for failure events**
- 🧠 Central logic for future **system telemetry**

---

## 📦 Tech Stack

- **.NET 8** Worker Service
- `HttpClient` + **dependency injection**
- **ILogger** / Serilog (future log pipeline)
- (Planned) **OpenTelemetry**, **Prometheus**, or **ELK**

---

## 📡 What Owla Tracks

- ✅ **Gateway health** (`GET /ping` to Unity)
- ✅ **Expired refresh token cleanup** (via `DELETE /tokens/expired` in Authix)
- 🔜 Service heartbeats and latencies
- 🔜 Central logging + traces
- 🔜 Performance telemetry

---

## 🔄 Current Flow

Every **10 seconds**, Owla:

1. Pings `Unity.Gateway` for availability.
2. Authenticates with `Authix.Auth` as a scout.
3. Calls `DELETE /tokens/expired` to clear stale refresh tokens.
4. Logs all outcomes with expressive emoji-enhanced messages 🦉✨

---

## 🧩 Integration Points

- 🦄 **Unity.Gateway** — checked for availability
- 🐉 **Authix.Auth** — cleanup and token purge
- 🧪 Future Byte Beasts — metrics, alerts, trace correlation

---

## ⚙️ Configuration Notes

Owla authenticates using standard login flow:

- Username: `"Owla"`
- Role: `scout`
- Password: stored securely via BCrypt

Add required environment variables (or Docker secrets) for:

```bash
OWLA_USERNAME=Owla
OWLA_PASSWORD=owlascout
AUTHIX_URL=http://authix.auth:8080
UNITY_URL=http://unity.gateway:8080
```

---

## 🧙 Deployment

- Included in `docker-compose.yml`
- Automatically starts with the rest of Bytewood
- Uses shared `bytewoodnet` network to talk to services by name

---

## 🔮 Future Roadmap

- [ ]  Centralized structured logging (e.g., Seq or ELK)
- [ ]  Prometheus metrics exporter
- [ ]  Service uptime dashboard
- [ ]  Failure trend analysis
- [ ]  Alert integration (Slack, email, etc.)
- [ ]  Support for gRPC service pings

---

> "Guardians protect, scouts explore… but it’s the observers who remember. That’s what makes Bytewood strong."