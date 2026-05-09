# WAVets2Tech Portal

A veteran-to-tech career platform built for Saint Martin's University's WAVets2Tech program. The application connects Washington state military veterans with technology career opportunities through a full-stack web application featuring job listings, veteran profiles, and an employer directory.

**Developer:** Landon Armstrong — Team Lead & Front-End Developer
**GitHub:** [Larmstrong1127](https://github.com/Larmstrong1127)
**Email:** Landon.Armstrong@stmartin.edu
**Institution:** Saint Martin's University

---

## Role

Led a cross-functional team of four developers through the full Software Development Life Cycle (SDLC) — from requirements gathering and design to implementation and testing. Responsible for front-end architecture and team coordination.

---

## Tech Stack

| Layer | Technology |
|---|---|
| Frontend | React, JavaScript (ES6+), HTML/CSS |
| Backend | ASP.NET Core Web API, C# |
| API Style | REST API |
| Database | SQL Server + Entity Framework Core |

---

## Features

- **Job Listings** — Browse open tech positions with search by title and filter by category and location
- **Veteran Profiles** — Discover veteran students available for hire, searchable by name and military branch
- **Employer Directory** — View participating tech companies fetched live from the REST API
- **Multi-section Navigation** — Single-page React app with Home, Jobs, Veterans, and Employers sections
- **Search and Filter** — Real-time filtering across jobs and veteran profiles
- **Responsive UI** — Professional indigo/purple theme, works on all screen sizes

---

## Project Structure

```
WAVets2Tech-master/
├── WAVets2Tech API/           # ASP.NET Core Web API
│   ├── Controllers/
│   │   ├── StudentController.cs
│   │   ├── EmployerController.cs
│   │   ├── CompanyController.cs
│   │   └── JobController.cs
│   ├── Models/
│   │   ├── Student.cs
│   │   ├── Employer.cs
│   │   ├── Company.cs
│   │   ├── Job.cs
│   │   └── Wavets2TechContext.cs
│   ├── ClientApp/
│   │   └── src/
│   │       └── App.js         # React SPA
│   └── Program.cs
└── WAVets2Tech API.sln
```

---

## Setup Instructions

### Prerequisites
- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [Node.js 16+](https://nodejs.org/)
- SQL Server (local or Express edition)

### Run Locally

```bash
# 1. Update the connection string in appsettings.json to point to your SQL Server instance

# 2. Apply database migrations
cd "WAVets2Tech API"
dotnet ef database update

# 3. Start the API (also serves the React frontend automatically)
dotnet run
```

The app will launch at `https://localhost:5001`. The React frontend is served via the ASP.NET Core + React integration.

### Run Frontend in Development Mode

```bash
cd "WAVets2Tech API/ClientApp"
npm install
npm start
```

---

## API Endpoints

| Method | Endpoint | Description |
|---|---|---|
| GET | `/api/student` | List all veteran students |
| GET | `/api/student/{id}` | Get student by ID |
| POST | `/api/student` | Create student profile |
| PUT | `/api/student/{id}` | Update student profile |
| DELETE | `/api/student/{id}` | Remove student |
| GET | `/api/company` | List all employer companies |
| GET | `/api/employer` | List all employer contacts |
| GET | `/api/job` | List all job postings |

---

## License

This project was developed as part of the WAVets2Tech program at Saint Martin's University. For educational and portfolio purposes.
