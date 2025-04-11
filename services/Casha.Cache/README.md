# Casha the Collector 🐢

> "Why ask again, when I already know?"

Casha quietly remembers answers others keep asking. She provides a safe, fast place to store and retrieve frequently-used data.

## 🔧 Purpose

- Caches API responses or calculated values
- Wraps Redis with friendly endpoints
- Exposes cache CRUD operations via REST

## 📦 Tech Stack

- .NET 8 Web API (Minimal API or MVC)
- Redis
- Cache-aside pattern

## 🗃️ Example Cache Keys

- `user:42:profile`
- `report:weekly:summary`

## 🧩 Integration Points

- Used by Unity.Gateway and others
- Invalidated by Tweetle events