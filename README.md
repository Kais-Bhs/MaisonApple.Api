# 🍎 MaisonApple - The Ultimate E-commerce Backend

Welcome to **MaisonApple**, a robust and scalable backend solution designed for a modern e-commerce platform. This project is built with a focus on clean architecture, performance, and maintainability, providing a solid foundation for managing products, users, orders, and essential communication.

## ✨ Key Features

MaisonApple is packed with features to run a complete e-commerce operation:

*   **User Management & Authentication:** Secure registration, login, and user profile management (`RegisterUserDto`, `LoginUserDto`, `UpdateUserDto`).
*   **Product Catalog:** Comprehensive management of products, categories, colors, and images (`Product`, `Category`, `ProductColor`, `ProductImage`).
*   **Order & Command System:** Handle customer orders, track command status, and manage the purchasing process (`Command`, `Order`, `CommandStatus`).
*   **Favorites:** Allow users to save their favorite products (`Favoris`).
*   **Notifications:** System for internal user notifications (`Notification`).
*   **✉️ Dedicated Email Service:** A separate, plug-and-play service for handling all email communications, including order confirmations, password resets, and promotional messages.

## 🛠️ Technologies Used

This project leverages the power of the Microsoft ecosystem to deliver a high-performance application:

| Technology | Role |
| :--- | :--- |
| **C# / .NET 8.0** | Core programming language and framework for the entire application. |
| **ASP.NET Core** | Used for building the Web API, handling HTTP requests, and routing. |
| **Entity Framework Core (EF Core)** | Object-Relational Mapper (ORM) for seamless database interaction and data management. |
| **FluentEmail** | Dedicated library for simple and efficient email sending (part of the `EmailService` project). |
| **Clean Architecture** | Project structure is divided into distinct layers (`Entities`, `DAO`, `DTO`, `EmailService`) for better separation of concerns. |

## 🏗️ Project Structure

The project is organized into several logical layers to ensure a clean and maintainable codebase:

```
MaisonApple/
├── DAO/                  # Data Access Objects (EF Core Context, Migrations)
├── DTO/                  # Data Transfer Objects (Data models for API communication)
├── EmailService/         # Dedicated service for all email sending logic
├── Entities/             # Core business entities (Database models)
└── MaisonApple/          # Main Web API project (Controllers, Program.cs)
    ├── Controllers/      # API Endpoints (Auth, Products, Orders, etc.)
    └── Program.cs        # Application startup and service configuration
```

## 🚀 Getting Started

### Prerequisites

*   .NET 8.0 SDK
*   A database (e.g., SQL Server, SQLite, PostgreSQL) compatible with EF Core.

### Installation

1.  **Clone the repository:**
    ```bash
    git clone [YOUR_REPO_URL]
    cd MaisonApple
    ```

2.  **Configure the Database:**
    Update the connection string in `MaisonApple/MaisonApple/appsettings.json` to point to your database.

3.  **Apply Migrations:**
    Navigate to the `DAO` project and apply the database migrations:
    ```bash
    dotnet ef database update --project MaisonApple/DAO/DAO.csproj
    ```

4.  **Configure Email Service:**
    Update the SMTP settings in `MaisonApple/MaisonApple/appsettings.json` for the `EmailService` to function correctly.

5.  **Run the Application:**
    ```bash
    dotnet run --project MaisonApple/MaisonApple/MaisonApple.csproj
    ```

The API will typically start on `http://localhost:5000` or `http://localhost:5001` (HTTPS).

## 📧 Email Functionality Explained

The project includes a dedicated `EmailService` to handle all transactional and marketing emails.

| Component | Purpose |
| :--- | :--- |
| `EmailService/IEmailSender.cs` | Defines the contract for sending emails. |
| `EmailService/EmailSender.cs` | Implements the email sending logic, likely using FluentEmail. |
| **Integration** | The main application injects `IEmailSender` into controllers or services to trigger emails for events like: **New User Registration**, **Order Confirmation**, **Password Reset**, etc. |

This separation ensures that the core business logic remains clean and independent of the email delivery mechanism.

## 🤝 Contributing

We welcome contributions! Please feel free to submit a Pull Request or open an Issue if you find a bug or have a feature suggestion.

---
*Built with 💖 and C#*
