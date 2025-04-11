# Squee the Scheduler 🐿️

> "Time is sacred. I keep the rhythm."

Squee keeps Bytewood’s routines in check. Every morning, every midnight — she ensures the forest runs on time, triggering jobs, reminders, and tasks across the land.

## 🔧 Purpose

- Runs scheduled tasks (daily/weekly/etc.)
- Triggers workflows via REST or RabbitMQ
- Maintains job log for observability

## 📦 Tech Stack

- .NET 8 Worker Service
- HostedService background execution
- (Optional: Hangfire or Quartz.NET)

## 🕰️ Example Jobs

- Clean old cache data via Casha
- Trigger summary reports
- Publish heartbeat events to Owla

## 🧩 Integration Points

- REST to other services (e.g., Casha)
- RabbitMQ for job eventss