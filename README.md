# RaceDay API

## Project Overview
RaceDay is an ASP.NET Core Web API for managing South African running, walking and cycling events. It supports event organisers and participants through role-specific functionality.

## User Roles
- **Organiser:** Creates and manages events and categories, views event enrolments, and records participant results.
- **Participant:** Browses events, enrols in categories, manages personal profile information, and views personal results.

## Technologies
- C# and ASP.NET Core Web API
- SQL Server
- Entity Framework Core
- Swagger / OpenAPI
- xUnit
- GitHub Actions

## Prerequisites
- Visual Studio or the .NET SDK compatible with the project
- SQL Server and SQL Server Management Studio
- Git

## Setup and Run
1. Clone the GitHub repository.
2. Open `raceday.sln` in Visual Studio.
3. Configure the SQL Server connection string in the appropriate local configuration.
4. Restore NuGet packages.
5. Apply the required Entity Framework Core migrations or follow the documented database setup procedure.
6. Build and run the API.
7. Open the Swagger URL shown by the application to test the endpoints.

## Testing
Run the tests from the solution directory:

`dotnet test raceday.sln`

## CI/CD
GitHub Actions builds the solution and runs the automated tests on pushes and pull requests. A screenshot of a successful workflow run is included below.

[successful GitHub Actions run here.]

## Demonstration Video
[YouTube video URL here.]

## Documentation
The `docs` folder contains the Part 1 planning documents and endpoint plan used to guide the implementation.
