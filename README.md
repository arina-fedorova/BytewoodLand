# 🧙‍♂️ BytewoodLand — A Microservices Fantasy Realm

## 🌍 The Land of Bytewood

In a distant digital realm called **Bytewood**, all the creatures are made of code. The skies shimmer with binary stars, and rivers flow with streams of data. It is a peaceful and productive land, where elegant software flows as naturally as air.

But one day…

Tasks start going unfinished.

Messages vanish in transit.

Caches grow cold.

The creatures of Bytewood are overwhelmed.

At the heart of Bytewood stands the **Council of Threads** — wise old programs who keep everything running smoothly. But even they cannot maintain balance alone. In desperation, they send out a call through the cloud…

> That’s where you come in — the great Architect of Logic 🧠

You’re not here to build just one service.

You're building a living, breathing **ecosystem** of clever, purposeful creatures:

tiny microservices known as the **Byte Beasts**.

Each Beast is:

- 💼 Focused on a single responsibility
- 🎭 Brought to life with a unique name and personality
- 🌐 Connected to the greater forest
- 🏡 Housed in its own project folder inside the BytewoodLand repository

Together, they form a resilient, scalable, and elegant digital civilization.

---

## 📣 About This Project — A Living Portfolio

> "I didn't just want to build another demo — I wanted to build a world."

**BytewoodLand** is more than a code sample — it’s a carefully crafted software ecosystem designed to showcase my real-world development and architectural skills.

This project was created as a **portfolio centerpiece**, highlighting my approach to:

- Designing scalable, containerized microservices
- Building clean, modular codebases in .NET
- Applying DevOps and cloud-native best practices
- Adding personality and creativity to system architecture

If you're a **recruiter**, **hiring manager**, or fellow **engineer**, this project is my way of saying:

> 💬 “Here’s how I think. Here’s how I code. Here’s how I build systems that are both fun and production-ready.”

---

## ⚙️ What Is BytewoodLand?

BytewoodLand is a fully containerized, fantasy-themed **.NET 8 microservices architecture demo**, built to showcase clean structure, composable design, cloud-readiness, and just the right touch of imagination.

Bytewood shows that code architecture can be **playful, powerful, and production-ready**.

---

## 🧱 Overview

This repository is a complete demonstration of:

- ✅ Modular service boundaries
- ✅ Clean shared contracts
- ✅ Containerized infrastructure
- ✅ Message-based communication (RabbitMQ)
- ✅ Health monitoring & logging
- ✅ Scalable, realistic microservice patterns

---

## 🐾 Meet the Byte Beasts

| Beast | Role | Type | Description |
| --- | --- | --- | --- |
| 🦄 Unity the Gateway | API Gateway | Web API | The central gatekeeper. Routes requests and validates JWTs. |
| 🐉 Authix the Gatekeeper | Auth Service | Web API | Issues JWT tokens. Controls access to the realm. |
| 🐦 Tweetle the Messenger | Messaging Worker | Worker | Handles events and message queues via RabbitMQ. |
| 🐿️ Squee the Scheduler | Timekeeper | Worker | Executes recurring background jobs. |
| 🐢 Casha the Collector | Cache Layer | Web API | Talks to Redis, stores memory for others. |
| 🦉 Owla the Observer | Watcher | Worker | Checks health and logs activity across the realm. |

---

## 📦 Tech Stack

- **.NET 8** (`webapi`, `worker`)
- **Docker + Docker Compose**
- **RabbitMQ** (events and queues)
- **Redis** (caching)
- **Swashbuckle** (Swagger for APIs)
- **StackExchange.Redis**
- **MassTransit** (optional, coming soon)
- **Serilog / OTel** (planned)

---

## 🚀 How to Run

### 🧰 Prerequisites

- Docker + Docker Compose v2
- .NET 8 SDK (for local dev/testing)

### 🐋 One Command to Rule Them All

```bash
docker compose up --build

```

- Access Gateway: `http://localhost:5000`
- Authix UI: `http://localhost:5001`
- Casha UI: `http://localhost:5002`
- RabbitMQ UI: `http://localhost:15672` (user/pass: guest/guest)

---

## 📂 Project Structure

```
BytewoodLand/
├── services/
│   ├── Unity.Gateway/
│   ├── Authix.Auth/
│   ├── Tweetle.Messenger/
│   ├── Squee.Scheduler/
│   ├── Casha.Cache/
│   └── Owla.Observer/
├── shared/
│   └── Bytewood.Contracts/
├── docker-compose.yml
└── README.md

```

---

## 🔮 Future Roadmap

- [x]  JWT-based auth flow from Unity → Authix
- [ ]  MassTransit with RabbitMQ
- [ ]  Event-driven cache invalidation
- [ ]  Serilog + centralized log storage
- [ ]  Prometheus/OpenTelemetry integration
- [ ]  CI/CD via GitHub Actions
- [ ]  Frontend visualization (storybook for beasts? 👀)

---

## 🧙‍♀️ Why This Exists

This is more than a codebase — it's a learning playground, a dev portfolio piece, a fantasy world, and a demonstration of how good software architecture **can be playful and powerful at once**.

Pull it. Run it. Expand it. Or just enjoy the lore ✨

---

> Built with magic by 🪄 Arina
