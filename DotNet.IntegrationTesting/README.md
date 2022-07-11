# .NET Integration Testing
.NET6 demos (with a presentation) that explain integration testing in details.

## Project structure
- [Docs](https://github.com/MTrajK/dotnet-projects/tree/main/DotNet.IntegrationTesting/Docs) - PowerPoint presentation and some notes.
- DemoX - The demos from the presentation (demo numbers could be found in the power point slide notes).

## Demo Apps
3 simple API apps:
- Demo 1: Simple temperature conversion app in 2 layers.
- Demo 2: Simple random cats fact generator app in 2 layers that uses an external API.
- Demo 3: Simple notes saving app that uses SQL DB and Entity Framework.

Used techs and things:
- .NET 6
- Web API
- Entity Framework
- Clean Architecture
- MSTest
- XUnit
- External API: https://catfact.ninja/

### Requirements
- MS SQL Server (needs to be installed for the Demo3, a database is used in Demo3)
  * or Docker instance with running MS SQL Server (if you already has Docker installed just run this command ```docker run -e "ACCEPT_EULA=Y" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2019-latest``` which will start a Docker instance and install SQL Server 2019 there)
  * or the third option is to use some remote database (you'll need to change the NotesDB connection string located in [appsettings.json](https://github.com/MTrajK/dotnet-projects/blob/main/DotNet.IntegrationTesting/Demo3/Src/DotNet.IntegrationTesting.Demo3.API/appsettings.json))
- Visual Studio (2022 at least for best experience)

### Start app
- Set as Startup Project the API project you want to run, for exampl Demo2 project -> Demo2/Src/DotNet.IntegrationTesting2.API and run the app.

### Run tests
- Use the test explorer UI, or go into the test class and right click to some method -> run test.

## Integration tests configuration

Integration tests in ASP.NET Core\
https://docs.microsoft.com/en-us/aspnet/core/test/integration-tests?view=aspnetcore-6.0

Nuget Packages that should be installed (the latest versions):
- Microsoft.AspNetCore.Mvc.Testing (to reconfigure the app startap using WebApplicationFactory)
- Microsoft.EntityFrameworkCore.InMemory (to use in-memory DB instead of real one)

## Entity framework configuration

Installing Entity Framework Core\
https://docs.microsoft.com/en-us/ef/core/get-started/overview/install

Getting started\
https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/intro?view=aspnetcore-6.0

---------------------------------------------

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

---------------------------------------------

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
cd <PROJECT PATH>\DotNet.IntegrationTesting\Demo3\Src\DotNet.IntegrationTesting.Demo3.Infrastructure
```


Create a migration
```powershell
dotnet ef migrations add InitialCreate
```
Create a migration - when running the command from a non-startup folder (because DB and API are in a different projects in this case)
```powershell
dotnet ef migrations add "Initial Migration" --startup-project  "../DotNet.IntegrationTesting.Demo3.API"
```


Update a migration in a database (and create a database if doesn't exist) -
```powershell
dotnet ef database update
dotnet ef database update "Migration Name"
dotnet ef database update MigrationName
```
Update a migration in a database (and create a database if doesn't exist) - when running the command from a non-startup folder
```powershell
dotnet ef database update --startup-project "../DotNet.IntegrationTesting.Demo3.API"
dotnet ef database update "Initial Migration" --startup-project  "../DotNet.IntegrationTesting.Demo3.API"
```

Remove latest migration
```powershell
dotnet ef migrations remove
```
Remove latest migration - when running the command a from non-startup folder
```powershell
dotnet ef migrations remove --startup-project  "../DotNet.IntegrationTesting.Demo3.API"
```


Delete the database
```powershell
dotnet ef database drop
```
Delete the database - when running the command from a non-startup folder
```powershell
dotnet ef database drop --startup-project  "../DotNet.IntegrationTesting.Demo3.API"
```
