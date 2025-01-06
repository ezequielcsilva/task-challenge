# Task Tracker Application
Task Tracker is a full-stack application for managing tasks, built with .NET 8 on the backend and React with Vite on the frontend.

## Features
- Task management with pagination and CRUD operations.
- Modern, responsive frontend using TailwindCSS and ShadCN UI.

## Tech Stack
- Frontend: React, Vite, TailwindCSS, ShadCN UI
- Backend: .NET 8, Entity Framework Core, Swagger

## Installation
### Prerequisites
- Node.js (v16+)
- .NET SDK (v8.0+)

### Steps
1. Clone the repository:
```bash
git clone https://github.com/your-repo/task-tracker.git
cd task-tracker
```

2. Backend Setup:
- Navigate to the backend folder:
```bash
cd src
```
- Restore dependencies:
```bash
dotnet restore
```
- Run the backend:
```bash
dotnet run --project TaskTracker.API
```

3. Frontend Setup:
- Navigate to the frontend folder:
```bash
cd frontend
```

- Install dependencies:
```bash
npm install
```

- Run the frontend:
```bash
npm run dev
```