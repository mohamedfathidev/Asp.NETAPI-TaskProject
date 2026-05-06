# ASP.NET Core Web API — Task Project

A RESTful Web API built with **ASP.NET Core** and **C#**, designed as a hands-on lab project for practicing core Web API concepts including routing, controllers, models, and HTTP operations.

---

## 🚀 Features

- RESTful API architecture following HTTP conventions
- Controller-based routing with ASP.NET Core
- CRUD operations (Create, Read, Update, Delete)
- JSON request/response handling
- Built with the modern `.slnx` Visual Studio solution format

---

## 🛠️ Tech Stack

| Technology | Details |
|---|---|
| Language | C# |
| Framework | ASP.NET Core Web API |
| IDE | Visual Studio (`.slnx` solution) |
| Runtime | .NET (latest compatible version) |

---

## 📁 Project Structure

```
Asp.NETAPI-TaskProject/
├── APILab/               # Main Web API project
│   ├── Controllers/      # API controllers and route handlers
│   ├── Models/           # Data models and DTOs
│   ├── Program.cs        # Application entry point
│   └── appsettings.json  # App configuration
└── APILab.slnx           # Visual Studio solution file
```

---

## ⚙️ Getting Started

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) (6.0 or later recommended)
- [Visual Studio 2022+](https://visualstudio.microsoft.com/) or [VS Code](https://code.visualstudio.com/) with the C# extension

### Clone the Repository

```bash
git clone https://github.com/mohamedfathidev/Asp.NETAPI-TaskProject.git
cd Asp.NETAPI-TaskProject
```

### Run the API

**Using .NET CLI:**

```bash
cd APILab
dotnet restore
dotnet run
```

**Using Visual Studio:**

1. Open `APILab.slnx`
2. Set `APILab` as the startup project
3. Press `F5` to run

The API will start on `https://localhost:{port}` by default. The exact port is shown in the terminal output.

---

## 📡 API Endpoints

> Base URL: `https://localhost:{port}/api`

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/tasks` | Retrieve all tasks |
| GET | `/tasks/{id}` | Retrieve a task by ID |
| POST | `/tasks` | Create a new task |
| PUT | `/tasks/{id}` | Update an existing task |
| DELETE | `/tasks/{id}` | Delete a task |

---

## 🧪 Testing the API

You can test the endpoints using:

- **Swagger UI** — available at `https://localhost:{port}/swagger` when running in development mode
- **Postman** — import the base URL and test each endpoint
- **curl** — example:

```bash
curl -X GET https://localhost:{port}/api/tasks
```

---

## 📄 License

This project is open source and available under the [MIT License](LICENSE).

---

## 👤 Author

**Mohamed Fathi**  
GitHub: [@mohamedfathidev](https://github.com/mohamedfathidev)
