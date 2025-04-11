# Owla the Observer 🦉

> "I see all. I log all. I remember what others forget."

Owla watches over Bytewood from the treetops. She logs each event, tracks service health, and sounds the alarm when things go awry.

## 🔧 Purpose

- Observability service
- Collects logs, health pings, metrics
- Emits alerts for failing services

## 📦 Tech Stack

- .NET 8 Worker Service
- Serilog (structured logs)
- OpenTelemetry / Prometheus
- HealthCheck consumers

## 📡 What Owla Tracks

- Service health statuses (via HTTP ping)
- Centralized logs (via seq / ELK / Grafana)
- Incoming alerts from other services

## 🧩 Integration Points

- All other services (health, logs, metrics)