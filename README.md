# 🏫 School Management System – Clean Architecture (ASP.NET Core Web API)

![.NET](https://img.shields.io/badge/.NET-8.0-blue?logo=dotnet) 
![EF Core](https://img.shields.io/badge/EF%20Core-7.0-lightgrey) 
![SQL Server](https://img.shields.io/badge/SQL%20Server-2019-red?logo=microsoftsqlserver)
![Docker](https://img.shields.io/badge/Docker-20.10-blue?logo=docker) 
![xUnit](https://img.shields.io/badge/xUnit-2.4-lightgrey) 
![MediatR](https://img.shields.io/badge/MediatR-10-orange)
![JWT](https://img.shields.io/badge/JWT-auth-purple)
![Serilog](https://img.shields.io/badge/Serilog-2.12-lightblue)

---

## 🌟 Overview
This is a full-featured School Management System built with ASP.NET Core Web API following Clean Architecture principles.  
The system is designed to be scalable, maintainable, and testable, incorporating modern development practices and patterns.

The project covers:

- Students  
- Instructors (with image uploads)  
- Departments & Subjects  
- Users & Roles  
- JWT Authentication & Role-Based Authorization  
- Welcome and Notification Emails via MailKit  
- Pagination, Standardized Response, and Data Seeding  

---

## 🏛 Architecture Layers

- Domain Layer  
- Application Core Layer  
- Application Services Layer  
- Infrastructure Layer  
- API Layer  

---

## 🛠 Key Features & Tech Stack

- ASP.NET Core Web API  
- SQL Server + EF Core  
- CQRS + MediatR  
- AutoMapper  
- Repository Pattern  
- JWT Authentication & Role Authorization  
- MailKit Email Integration  
- Serilog Logging  
- Custom Middleware & Filters  
- Pagination + Standard Response Result  
- Unit Testing with xUnit  
- Docker (Dockerfile + Docker Compose)  
- CORS & Data Seeding

---

## ⚡️ Getting Started

### Prerequisites
- .NET 9 SDK  
- SQL Server (local or Docker)  
- Docker (for containerized setup)  

### Setup
1. Clone the repository:  
`bash
git clone https://github.com/sobhi2006/SchoolProject.git