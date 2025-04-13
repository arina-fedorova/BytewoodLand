# Tweetle the Messenger 🐦

> "Even in chaos, I deliver."

Tweetle zips across Bytewood delivering messages between services. No matter the storm, Tweetle ensures each message
reaches its destination — eventually and reliably.

## 🔧 Purpose

- Handles asynchronous message sending and receiving
- Publishes and subscribes to RabbitMQ events
- Implements messaging contracts from `Bytewood.Contracts`

## 📦 Tech Stack

- .NET 8 Worker Service
- RabbitMQ
- MassTransit (optional)

## 📨 Handled Events

- `UserRegisteredEvent`
- `CacheInvalidatedEvent`
- (More coming soon...)

## 🧩 Integration Points

- Publishes and consumes messages on RabbitMQ
- Coordinates with services like Casha, Owla, etc.