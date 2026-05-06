# APILab

APILab is an ASP.NET Core 10 Web API demo project with JWT authentication, Identity-based user management, Entity Framework Core, SQL Server, repository/unit-of-work patterns, and Swagger/OpenAPI support.

## Key Features

- JWT authentication and token refresh flow
- Identity user management with roles (`Student`, `Admin`)
- Student and Department CRUD APIs
- Entity Framework Core with SQL Server
- Repository/UnitOfWork design for data access
- Custom validation attributes and filters
- Global exception handling middleware
- NLog logging integration
- Swagger/OpenAPI documentation in development

## Technology Stack

- .NET 10
- ASP.NET Core Web API
- Entity Framework Core 10
- SQL Server
- ASP.NET Core Identity
- JWT Bearer authentication
- Mapster mapping configuration
- NLog for logging
- Swashbuckle for Swagger

## Project Structure

- `Program.cs` - app startup and service configuration
- `Controllers/` - API controllers for authentication, students, departments
- `Models/` - EF Core entities and `ApplicationUser`
- `DTOs/` - request/response models for authentication
- `Repos/` - repository implementations
- `UnitOfWork/` - unit-of-work abstraction and implementation
- `Customs/` - custom filters, middleware, and validation attributes
- `Configs/` - mapping configuration
- `Migrations/` - EF Core database migrations

## Getting Started

### Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/10.0)
- SQL Server instance
- Optional: Visual Studio / VS Code

### Run locally

1. Open the solution in Visual Studio or the folder in VS Code.
2. Update the connection string in `appsettings.json` if needed:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=APIDb;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

3. Restore packages and build:

```bash
dotnet restore
dotnet build
```

4. Apply EF Core migrations:

```bash
dotnet ef database update
```

5. Run the API:

```bash
dotnet run
```

6. When running in development, open Swagger UI for exploration:

```text
https://localhost:{port}/swagger
```

## Authentication Flow

The API uses JWT tokens and refresh tokens via ASP.NET Core Identity.

### Available auth endpoints

- `POST /api/Account/register/student` — register a student account
- `POST /api/Account/register/admin` — register an admin account
- `POST /api/Account/login` — sign in and receive access + refresh tokens
- `POST /api/Account/refresh-token` — refresh an expired access token

### JWT settings

Configured in `appsettings.json` under `Jwt`:

- `Key`
- `Issuer`
- `Audience`

## API Endpoints

### Student API

- `GET /api/Student` — list all students (requires role `Student` or `Admin`)
- `GET /api/Student/{id:int}` — get student by ID
- `GET /api/Student/{name:alpha}` — get student by name
- `POST /api/Student` — create a student
- `PUT /api/Student` — update a student
- `DELETE /api/Student` — delete a student

### Department API

- `GET /api/Department/getAllDepts` — get all departments
- `GET /api/Department` — get departments with students
- `GET /api/Department/{id:int}` — get department by ID
- `POST /api/Department` — add a department

## Notes

- Custom validation attributes enforce rules such as unique email/name and past dates.
- Custom middleware handles exceptions and returns consistent error responses.
- CORS is configured with an `AllowAll` policy.
- Swagger/OpenAPI is enabled only in development.

## Useful Commands

```bash
dotnet restore
dotnet build
dotnet ef database update
dotnet run
```

## Contact

For questions or enhancements, inspect the controllers in `Controllers/` and the repository abstractions in `Repos/` and `UnitOfWork/`.
