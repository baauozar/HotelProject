
# 🏨 Hotel Management System

A comprehensive hotel management system built with ASP.NET Core MVC and Web API, featuring a multi-layered architecture and modern web technologies.

![.NET Core](https://img.shields.io/badge/.NET%20Core-8.0-blue)
![Entity Framework Core](https://img.shields.io/badge/EF%20Core-8.0-green)
![Bootstrap](https://img.shields.io/badge/Bootstrap-5.0-purple)
![License](https://img.shields.io/badge/license-MIT-orange)

## 📋 Table of Contents
- [Overview](#overview)
- [Architecture](#architecture)
- [Features](#features)
- [Technologies](#technologies)
- [Getting Started](#getting-started)
- [Project Structure](#project-structure)
- [API Documentation](#api-documentation)
- [Security](#security)
- [Contributing](#contributing)

## 🎯 Overview

This Hotel Management System is an educational project demonstrating modern web development practices with ASP.NET Core. It includes both a Web API backend and an MVC frontend, implementing features like room management, booking systems, staff management, and customer testimonials.

## 🏗️ Architecture

The project follows a **N-tier architecture** pattern with the following layers:

```
┌─────────────────────────────────────────────────────────┐
│                   Presentation Layer                    │
│                (HotelProject.UI & WebApi)              │
├─────────────────────────────────────────────────────────┤
│                     Business Layer                      │
│               (HotelProject.BusinessLayer)             │
├─────────────────────────────────────────────────────────┤
│                   Data Access Layer                     │
│              (HotelProject.DataAccessLayer)            │
├─────────────────────────────────────────────────────────┤
│                      Entity Layer                       │
│                (HotelProject.EntityLayer)              │
├─────────────────────────────────────────────────────────┤
│                        DTO Layer                        │
│                 (HotelProject.DtoLayer)                │
└─────────────────────────────────────────────────────────┘
```

## ✨ Features

### 👥 User Management
- **Staff Management**: CRUD operations for hotel staff
- **Guest Registration**: Customer profile management
- **Role-based Access**: Admin and staff roles

### 🏨 Hotel Operations
- **Room Management**: Add, update, delete rooms with detailed information
- **Booking System**: Complete reservation workflow
- **Service Management**: Additional hotel services tracking
- **About Section**: Dynamic hotel information management

### 📊 Dashboard & Analytics
- **Admin Dashboard**: Real-time statistics and metrics
- **Instagram Integration**: Social media follower count display
- **Testimonials**: Customer feedback management

### 📧 Communication
- **Email System**: Automated email notifications
- **Contact Messages**: Guest inquiry handling
- **Newsletter**: Subscriber management system

## 🛠️ Technologies

### Backend
- **ASP.NET Core 8.0** - Web framework
- **Entity Framework Core 8.0** - ORM
- **SQL Server** - Database
- **Identity Framework** - Authentication & Authorization
- **FluentValidation** - Input validation
- **AutoMapper** - Object mapping

### Frontend
- **MVC Pattern** - Architectural pattern
- **Razor Pages** - View engine
- **Bootstrap 5** - CSS framework
- **jQuery** - JavaScript library
- **AJAX** - Asynchronous requests

### Tools & Libraries
- **MailKit** - Email sending
- **Newtonsoft.Json** - JSON serialization
- **ViewComponents** - Reusable UI components
- **User Secrets** - Secure configuration

## 🚀 Getting Started

### Prerequisites
- .NET 6.0 SDK or later
- SQL Server 2019 or later
- Visual Studio 2022 (recommended) or VS Code

### Installation

1. **Clone the repository**
   ```bash
   git clone https://github.com/yourusername/hotel-management-system.git
   cd hotel-management-system
   ```

2. **Configure User Secrets**
   ```bash
   cd HotelProject.UI
   dotnet user-secrets init

   # Set email configuration
   dotnet user-secrets set "EmailSettings:SenderEmail" "your-email@gmail.com"
   dotnet user-secrets set "EmailSettings:Password" "your-app-password"

   # Set API configuration
   dotnet user-secrets set "ApiSettings:BaseUrl" "https://localhost:44369"

   # Set Instagram API (optional)
   dotnet user-secrets set "RapidApi:Key" "your-rapidapi-key"
   dotnet user-secrets set "Instagram:Username" "your-instagram-username"
   ```

3. **Update Database**
   ```bash
   cd HotelProject.WebApi
   dotnet ef database update
   ```

4. **Run the Applications**
   ```bash
   # Terminal 1 - API
   cd HotelProject.WebApi
   dotnet run

   # Terminal 2 - UI
   cd HotelProject.UI
   dotnet run
   ```

## 📁 Project Structure

```
Solution/
├── ApiConsume/
│   ├── HotelProject.BusinessLayer/    # Business logic and services
│   ├── HotelProject.DataAccessLayer/  # Repository pattern & EF Core
│   ├── HotelProject.DtoLayer/         # Data Transfer Objects
│   ├── HotelProject.EntityLayer/      # Domain entities
│   └── HotelProject.WebApi/           # RESTful API endpoints
│
└── Frontend/
    └── HotelProject.UI/               # MVC Web Application
        ├── Controllers/               # MVC Controllers
        ├── Dtos/                      # UI-specific DTOs
        ├── Mapping/                   # AutoMapper profiles
        ├── Model/                     # ViewModels
        ├── ValidationRules/           # FluentValidation rules
        ├── ViewComponents/            # Reusable components
        └── Views/                     # Razor views
```

## 📊 API Documentation

### Key Entities
- **About** - Hotel information
- **AppRole** - User roles
- **AppUser** - User accounts
- **Booking** - Reservations
- **Contact** - Contact messages
- **Guest** - Customer profiles
- **Room** - Hotel rooms
- **Service** - Hotel services
- **Staff** - Employee records
- **Subscribe** - Newsletter subscribers
- **Testimonial** - Customer reviews
- **WorkLocation** - Office locations

## 🔒 Security

### Current Implementation
- ✅ User Secrets for sensitive configuration
- ✅ CSRF protection on forms
- ✅ Input validation with FluentValidation
- ✅ SQL injection protection via Entity Framework
- ✅ Authentication with Identity Framework

### ⚠️ Educational Note
This project is for educational purposes. For production use, implement:
- JWT authentication for API
- Rate limiting
- HTTPS enforcement
- API versioning
- Comprehensive error handling
- Audit logging
- Data encryption

## 🧪 Validation Examples

### Room Validation
```csharp
RuleFor(x => x.Title).NotEmpty().MaximumLength(100);
RuleFor(x => x.Price).GreaterThan(0);
RuleFor(x => x.BedCount).InclusiveBetween(1, 10);
RuleFor(x => x.Wifi).Must(x => x == "Free" || x == "Paid");
```

### Booking Validation
```csharp
RuleFor(x => x.Name).NotEmpty().MinimumLength(2);
RuleFor(x => x.Mail).EmailAddress();
RuleFor(x => x.CheckOut).GreaterThanOrEqualTo(x => x.Checkin.AddDays(1));
```


## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.




