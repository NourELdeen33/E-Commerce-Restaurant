# 🍔 E-Commerce Restaurant System

A robust, full-featured web application built with **ASP.NET Core MVC**. This project showcases a clean architecture approach for managing a professional restaurant's online presence, from menu customization to secure order processing.

---

## 🚀 Technical Highlights

### 🏛️ Architecture & Patterns
* **Repository Pattern:** Decoupled business logic from data access using Generic and Specialized repositories for better maintainability and testability.
* **Clean Data Modeling:** Implemented a complex database schema including **Many-to-Many** relationships (Products ↔️ Ingredients) managed via EF Core Fluent API.
* **Separation of Concerns:** Organized the project using dedicated **ViewModels** and **Entity Configurations** to keep the `DbContext` clean and focused.

### 🔐 Security & User Management
* **ASP.NET Core Identity:** Fully integrated authentication system with Role-Based Access Control (RBAC).
* **Secure Workflows:** Managed user sessions, password hashing, and account-specific order history.

### 🛒 E-Commerce Engine
* **Smart Shopping Cart:** Session-based cart system with custom extensions for object serialization.
* **Inventory Guard:** Real-time stock validation that prevents ordering out-of-stock items and automatically updates inventory upon purchase.
* **Image Processing:** Custom service for secure file uploads and automated server-side image management.

---

## 🛠️ Tech Stack

* **Backend:** C# | ASP.NET Core MVC 
* **Database:** Entity Framework Core | SQL Server | LINQ
* **Authentication:** ASP.NET Core Identity
* **Frontend:** Razor Views | Bootstrap | jQuery (Client-side Validation)
* **State Management:** Sessions & Cookies

---

## 📸 Project Structure Overview

Based on the implemented design:
* **Models/Config:** Fluent API configurations for database integrity.
* **Repositories:** Implementation of the data access layer.
* **Interfaces:** Abstractions for the Repository pattern.
* **Controllers:** Lean controllers utilizing Dependency Injection.

**This is my first ASP.NET Core MVC project, focused on learning best practices and scalable backend design.**
