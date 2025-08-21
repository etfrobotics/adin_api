# ADIN API

ADIN API is an ASP.NET Core 5.0 Web API for managing maintenance tasks and the resources required for each task. It supports user authentication, structured logging, and Docker-based setup for local development.

## Features
- Entity Framework Core with PostgreSQL (or SQL Server) support
- Repository + Unit-of-Work pattern
- AutoMapper DTO↔model mapping
- Serilog logging
- JWT authentication & role-based authorization (User, Administrator)
- Swagger UI for interactive documentation
- Static file hosting for uploaded images (`/files`)

## Prerequisites
- [.NET 5 SDK](https://dotnet.microsoft.com/download/dotnet/5.0)
- Docker & Docker Compose (optional)
- PostgreSQL or SQL Server instance

## Getting Started

### 1. Clone
```bash
git clone <repo-url>
cd adin_api
```

### 2. Configure
Edit `adin_api/appsettings.json` with connection strings. Example for PostgreSQL:

```json
"ConnectionStrings": {
  "postgreSQLstring": "Host=localhost;Port=5432;Database=adin_db_postgres;Username=admin;Password=AdinApp2022!"
}
```
Switch to `UseSqlServer` in `Startup.cs` to use `sqlConnection`.

### 3. Run with .NET CLI
```bash
dotnet restore
dotnet build
dotnet ef database update
dotnet run --project adin_api
```
Access API at `http://localhost:5000` and Swagger at `/swagger`.

### 4. Run with Docker Compose
```bash
docker-compose up --build
```
API available at `http://localhost:8000`.

### 5. Host Local Files
Create a folder named `files` on your PC. Place any static assets inside and ensure the API is configured to serve this folder (see documentation). The contents will then be available from the API at `/files`.

## Authentication
A default administrator is seeded:

| Email            | Password     |
|-----------------|--------------|
| knezevic@etf.rs | AdinApp2022! |

- `POST /api/Login` to obtain JWT.
- Include the token as `Authorization: Bearer <token>`.
- `POST /api/Register` is restricted to administrators.

## Key Endpoints
- `POST /api/Login` – Authenticate user
- `POST /api/Register` – Register user (admin only)
- `GET /api/Tasks` – List tasks
- `GET /api/Tasks/{id}` – Task details with steps & resources
- `POST /api/Tasks`, `PUT /api/Tasks/{id}`, `DELETE /api/Tasks/{id}` – Task management
- `GET /api/Components`, `GET /api/Tools`, `GET /api/SafetyTools`, `GET /api/Steps` – Resource endpoints
- `POST /api/Images` – Upload image (served from `/files`)

Explore the full API via Swagger UI.

## Project Structure
```
adin_api/
├─ Controllers/         # API controllers
├─ DTOs/                # Data transfer objects
├─ Data/
│  ├─ Models/           # Entity models
│  ├─ Repository/       # Repositories & unit of work
│  └─ Configuration/    # EF Core configuration & seed data
├─ Services/            # Authentication services
├─ Program.cs
├─ Startup.cs
├─ Dockerfile
└─ docker-compose.yml
```

## License
No license has been specified for this repository.
