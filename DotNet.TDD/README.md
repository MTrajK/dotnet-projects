# .NET TDD
NET Core demos (with a presentation) that explain TDD in details.\
TDD stands for test-driven development.

## Project structure
- [Docs](https://github.com/MTrajK/dotnet-projects/tree/main/DotNet.TDD/Docs) - PowerPoint presentation and some notes.
- [SimpleDemos](https://github.com/MTrajK/dotnet-projects/tree/main/DotNet.TDD/SimpleDemos) - Several simple TDD demos.
- [DeskBooking](https://github.com/MTrajK/dotnet-projects/tree/main/DotNet.TDD/DeskBooking) - Simple desk booking web API with unit and integration tests.

## Used techs and things:
- .NET Core
- Web API
- Entity Framework
- Clean Architecture
- MSTest
- XUnit
- NUnit
- FluentAssertions
- MS Sql server
- Docker
- Docker.DotNet

### Requirements
- Visual Studio (2022 at least for best experience)
- Docker (used in DeskBooking for the integration tests, TestDockerWebApplicationFactory)
  * or MS SQL Server installed locally, or use some remote database and change the DeskBookingDB connection string located in [appsettings.json](https://github.com/MTrajK/dotnet-projects/blob/main/DotNet.TDD/DeskBooking/Src/DotNet.TDD.DeskBooking.API/appsettings.json) (but using some of these ways you won't be able to use TestDockerWebApplicationFactory in the integration tests, because it requires Docker)

## DeskBooking app

### Start app
- Docker way: Start Docker and run docker-compose (run Docker Compose using Visual Studio or using command line - ```docker compose -f``` [docker-compose.yml](https://github.com/MTrajK/dotnet-projects/blob/main/DotNet.TDD/DeskBooking/docker-compose.yml))
- Non-Docker way: Set as Startup Project the API project -> DeskBooking/Src/DotNet.TDD.DeskBooking.API and run the app (but in this case you must have MS SQL Server installed locally, or you should access some remote database).

### Run tests
- Use the test explorer UI, or go into the test class and right click to some method -> run test.

### Integration tests configuration

Integration tests in ASP.NET Core\
https://docs.microsoft.com/en-us/aspnet/core/test/integration-tests?view=aspnetcore-6.0

Nuget Packages that should be installed (the latest versions):
- Microsoft.AspNetCore.Mvc.Testing (to reconfigure the app startap using WebApplicationFactory)
- Microsoft.EntityFrameworkCore.InMemory (to use in-memory DB instead of real one - used in [TestInMemoryWebApplicationFactory](https://github.com/MTrajK/dotnet-projects/blob/main/DotNet.TDD/DeskBooking/Tests/DotNet.TDD.DeskBooking.IntegrationTests/Setup/TestInMemoryWebApplicationFactory.cs))
- Docker.DotNet (used in [TestDockerWebApplicationFactory](https://github.com/MTrajK/dotnet-projects/blob/main/DotNet.TDD/DeskBooking/Tests/DotNet.TDD.DeskBooking.IntegrationTests/Setup/TestDockerWebApplicationFactory.cs))

### Docker configuration

***Note: this is optional in case you don't want to use docker compose (see [Start app](#start-app))***

Start a Docker instance with MS SQL Server:
```powershell
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=DotNetTDD2022" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2019-latest
```

Stop a Docker instance (the database will stay the same, no data will be lost, just the instance will be paused/unacessable):
```powershell
docker stop <instance name or instance id>
```
example: ```docker stop a25cec979cd8d25120f33c41a1b9ef44d84ca70abd9e60d747a31f8ecfc84bfe```

Start a Docker instance (after the istance was stopped):
```powershell
docker start <instance name or instance id>
```

Remove a Docker instance (this will remove the instance with all data/database):
 - First stop it and after that remove it
```powershell
docker stop <instance name or instance hash>
docker rm <instance name or instance hash>
```
- Or force remove
```powershell
docker rm <instance name or instance hash> -f
```

### Entity framework configuration

Installing Entity Framework Core\
https://docs.microsoft.com/en-us/ef/core/get-started/overview/install

Getting started\
https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/intro?view=aspnetcore-6.0


**Setup the projects and code**

Nuget Packages that should be installed (the latest versions):
- Microsoft.EntityFrameworkCore and Microsoft.EntityFrameworkCore.SqlServer (in the DB project, in this case Infrastructure project)
- Microsoft.EntityFrameworkCore.Design (in the startup project, in this case API project)

Code that should be implemented:
1. Create entities
2. Create the database context (inherits from DbContext)
3. Register the new context (startup -> ConfigureServices)
```cs
services.AddDbContext<SchoolContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
```
4. Create DbInitializer (use that in the startup from CreateDbIfNotExists - see the link from above)


**Setup the command line interface and update the DB using CLI**

***Note: This isn't mandatory, this is just in case you want to use the EF CLI to update/drop a DB, or to create/remove a migration to an existing database (for example if you have some data in the db - local or remote server - and you want to update the db with a newer db scheme). Otherwise, in this case, the database will be created from the code (CreateDatabase.CreateDbIfNotExists in Demo3).***

Install dotnet ef globally (the latest version)
```powershell
dotnet tool install --global dotnet-ef
```

Or update dotnet ef globally (to the latest version, if you have an older version)
```powershell
dotnet tool update --global dotnet-ef
```


Go in the DB project (in this case Infrastructure project)
```powershell
cd <PROJECT PATH>\DotNet.TDD\DeskBooking\Src\DotNet.TDD.DeskBooking.Infrastructure
```


Create a migration
```powershell
dotnet ef migrations add InitialCreate
```
Create a migration - when running the command from a non-startup folder (because DB and API are in a different projects in this case)
```powershell
dotnet ef migrations add "Initial Migration" --startup-project  "../DotNet.TDD.DeskBooking.API"
```


Update a migration in a database (and create a database if doesn't exist) -
```powershell
dotnet ef database update
dotnet ef database update "Migration Name"
dotnet ef database update MigrationName
```
Update a migration in a database (and create a database if doesn't exist) - when running the command from a non-startup folder
```powershell
dotnet ef database update --startup-project "../DotNet.TDD.DeskBooking.API"
dotnet ef database update "Initial Migration" --startup-project  "../DotNet.TDD.DeskBooking.API"
```

Remove latest migration
```powershell
dotnet ef migrations remove
```
Remove latest migration - when running the command a from non-startup folder
```powershell
dotnet ef migrations remove --startup-project  "../DotNet.TDD.DeskBooking.API"
```


Delete the database
```powershell
dotnet ef database drop
```
Delete the database - when running the command from a non-startup folder
```powershell
dotnet ef database drop --startup-project  "../DotNet.TDD.DeskBooking.API"
```
