# Notification Service

A scalable and clean-architecture-based Notification Service built with .NET.  
This service supports real-time and template-based notifications using RabbitMQ for messaging and follows Repository Pattern with SQL-based persistence.

---

## 🚀 Features

- ✅ Clean Architecture (Domain, Application, Infrastructure, Presentation)
- ✅ RabbitMQ Integration
- ✅ Template-based Notifications
- ✅ Simple (Direct) Notifications
- ✅ Template Management (CRUD)
- ✅ Mark Notification as Read
  - Mark all as read
  - Mark for a specific user
- ✅ SQL Database
- ✅ Repository Pattern
- ✅ Scalable & Maintainable Design

---

## 🏗️ Architecture

The project follows **Clean Architecture** principles:

### Domain Layer
Contains the core business entities and contracts.

- Entities
- Enums
- Value Objects
- Repository Interfaces

### Application Layer
Contains application business logic and use cases.

- DTOs
- Services
- Interfaces
- Use Cases
- Validation

### Infrastructure Layer
Implements external dependencies and persistence.

- Repository Implementations
- Database Context
- RabbitMQ Consumers
- External Services

### API Layer
Exposes REST endpoints for interacting with the system.

- Controllers
- Middleware
- Dependency Injection
- Request / Response Models

---

## Notification Types

### Simple Notification

A direct notification sent to a specific user.

Example:
```json
{
  "userId": "123",
  "title": "Account Created",
  "message": "Your account has been successfully created."
}
🚀 Notification Service – .NET | Clean Architecture | RabbitMQ

I recently built a scalable Notification Service using .NET, designed with Clean Architecture principles and asynchronous messaging via RabbitMQ.

The goal was to create a flexible system capable of handling both direct notifications and template-based notifications, while keeping the architecture modular and maintainable.

🔹 Key Features

• Simple notifications with custom title and message

• Template-based notifications with dynamic parameters

• Full template management (Create, Update, Delete, Retrieve)

• Mark notifications as read (all or per user)

• SQL Server persistence using Entity Framework Core

• Repository Pattern implementation

• RabbitMQ-based message processing

🔹 Architecture

The service follows a Clean Architecture structure:

Domain (Entities & Contracts)
Application (Business Logic & Use Cases)
Infrastructure (Database, RabbitMQ, Repositories)
API Layer (REST Endpoints)
🔹 Technology Stack

• .NET 8

• ASP.NET Core Web API

• Entity Framework Core

• SQL Server

• RabbitMQ

• Repository Pattern

🔹 Notification Types

1️⃣ Simple Notification

Direct message sent to a user.

2️⃣ Template Notification

Uses predefined templates with dynamic parameters for flexible messaging.

🔹 RabbitMQ Workflow

A message is published to RabbitMQ
The notification service consumes the message
Business logic processes the notification
The notification is stored in the database
This architecture allows the service to remain loosely coupled, scalable, and ready for extensions like Email, SMS, or Push notifications.
