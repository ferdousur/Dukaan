# Dukaan - Multi-Tenant E-Commerce Platform

Dukaan is a robust, multi-tenant e-commerce platform built with ASP.NET Core. It provides a foundation for merchants to register their own stores (tenants) and manage them independently.

## Features

- **Multi-Tenancy**: Support for multiple isolated stores within a single application instance.
- **Identity Management**: Integrated ASP.NET Core Identity for secure merchant authentication and authorization.
- **JWT Authentication**: Secure token-based authentication with tenant isolation (`tenant_id` claim).
- **Clean Architecture**: Organized into logical layers (Domain, Application, Infrastructure, Host) for maintainability and scalability.
- **Generic Repository Pattern**: Standardized data access layer for consistency across entities.
- **PostgreSQL Integration**: High-performance relational database storage using Entity Framework Core.

## Project Structure

```text
Dukaan/
├── Application/           # DTOs, Mappers, and Application Logic
│   └── Dtos/              # Data Transfer Objects (LoginRequest.cs, RegisterRequest.cs)
├── Domain/                # Core Business Logic and Entities
│   ├── Entities/          # Database Models (e.g., Tenant, Merchant)
│   └── Interfaces/        # Domain-level abstractions (e.g., ITenantEntity)
├── Host/                  # API Controllers and Entry Point
│   └── Controllers/       # REST API Endpoints
│           ├── AuthController.cs      # Authentication: Login, Register
│           └── TenantsController.cs   # Tenant management
├── Infrastructure/        # External Concerns (Database, Services)
│   ├── Data/              # EF Core Context and Repositories
│   │   ├── DbContext/
│   │   │   └── ApplicationDbContext.cs
│   │   ├── Model/
│   │   │   └── Merchant.cs
│   │   └── Repositories/
│   │       └── Repository.cs
│   ├── Migrations/        # Database Schema Versions
│   └── Services/          # Business Services
│           ├── AuthService.cs      # JWT token generation & validation
│           ├── IAuthService.cs     # Service contract
│           └── TenantService.cs    # Tenant-related operations
├── Properties/            # Project configuration (launchSettings.json)
├── Program.cs             # Application bootstrap, DI & JWT configuration
├── appsettings.json       # Database connection strings & environment settings
└── docs.txt               # Additional documentation notes

## Technologies Used

- **Framework**: ASP.NET Core 10.0
- **Database**: PostgreSQL
- **ORM**: Entity Framework Core
- **Identity**: Microsoft.AspNetCore.Identity.EntityFrameworkCore
- **Authentication**: JWT Bearer Tokens (System.IdentityModel.Tokens.Jwt)
- **Documentation**: OpenAPI (Swagger)

## Getting Started

### Prerequisites

- .NET 10 SDK
- PostgreSQL Server

### Setup

1.  **Clone the repository**:
    ```bash
    git clone <repository-url>
    ```

2.  **Configure the database**:
    Update the `DefaultConnection` in `appsettings.json` with your PostgreSQL credentials.

3.  **Run Migrations**:
    ```bash
    dotnet ef database update
    ```

4.  **Run the Application**:
    ```bash
    dotnet run --project Dukaan/Dukaan.csproj
    ```

## API Documentation

Once the application is running in development mode, you can access the OpenAPI documentation at:
`https://localhost:<port>/openapi/v1.json` (or use the interactive UI if configured).
