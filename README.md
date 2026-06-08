# Notification Service

A scalable and clean-architecture-based Notification Service built with .NET. This service supports real-time and template-based notifications using RabbitMQ for messaging and follows the Repository Pattern with SQL-based persistence.

---

## 🚀 Features

- ✅ **Clean Architecture:** Separation of concerns (Domain, Application, Infrastructure, API)
- ✅ **RabbitMQ Integration:** Asynchronous message processing for high scalability
- ✅ **Template-based Notifications:** Dynamic messaging with predefined templates
- ✅ **Simple (Direct) Notifications:** Instant alerts with custom content
- ✅ **Template Management:** Full CRUD operations for notification templates
- ✅ **Notification Management:** Mark notifications as read (all or per user)
- ✅ **SQL Persistence:** Reliable data storage using Entity Framework Core
- ✅ **Repository Pattern:** Clean abstraction for data access

---

## 🏗️ Architecture

The project adheres to Clean Architecture principles to ensure modularity and maintainability:

*   **Domain Layer:** Core business entities, enums, value objects, and repository interfaces.
*   **Application Layer:** Application business logic, use cases, DTOs, and validation.
*   **Infrastructure Layer:** Implementation of external dependencies including Database Context, Repositories, and RabbitMQ Consumers.
*   **API Layer:** RESTful endpoints, controllers, dependency injection, and middleware.

---

## 📩 Notification Types

### 1. Simple Notification
Direct notification sent to a specific user.

```json
{
  "userId": "123",
  "title": "Account Created",
  "message": "Your account has been successfully created."
}
```

### 2. Template Notification
Uses predefined templates with dynamic parameters.

```json
{
  "userId": "123",
  "templateCode": "WELCOME_TEMPLATE",
  "parameters": {
    "UserName": "Zeinab"
  }
}
```

---

## ⚙️ RabbitMQ Workflow

1.  **Publish:** A notification message is published to the RabbitMQ exchange.
2.  **Consume:** The Notification Service consumes the message from the queue.
3.  **Process:** The application layer processes the business logic.
4.  **Persist:** The notification is stored in the SQL database.

---

## 🛠️ Technology Stack

- **Framework:** .NET 10
- **API:** ASP.NET Core Web API
- **ORM:** Entity Framework Core
- **Database:** SQL Server
- **Messaging:** RabbitMQ
- **Design Pattern:** Repository Pattern, Clean Architecture

---

## 🚀 Running the Project

### 1. Clone the repository
```bash
git clone https://github.com/ZeynabNadiDev/NotificationService.git
```

### 2. Configure `appsettings.json`
Update your connection strings and RabbitMQ credentials.

### 3. Apply Migrations
```bash
dotnet ef database update
```

### 4. Run the Application
```bash
dotnet run
```

---

## 📄 License
MIT License
