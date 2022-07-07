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

### Requirement for best experience
Visual Studio 2022 (at least, if there is newer version in future)

### Start app
- Set as Startup Project the API project you want to run, for example -> Demo2/Src/DotNet.IntegrationTesting2.API and run the app.

### Run tests
- Use the test explorer UI, or go into the test class and right click to some method -> run test.

## Integration tests configuration

Integration tests in ASP.NET Core\
https://docs.microsoft.com/en-us/aspnet/core/test/integration-tests?view=aspnetcore-6.0

Nuget Packages that should be installed (the latest versions):
- Microsoft.AspNetCore.Mvc.Testing (to manipulate the app startap using WebApplicationFactory)
- Microsoft.EntityFrameworkCore.InMemory (to use in-memory DB instead of real one)

## Entity framework configuration

Installing Entity Framework Core\
https://docs.microsoft.com/en-us/ef/core/get-started/overview/install

Getting started\
https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/intro?view=aspnetcore-6.0

---------------------------------------------

**Setup the projcets and code**

Nuget Packages that should be installed (the latest versions):
- Microsoft.EntityFrameworkCore and Microsoft.EntityFrameworkCore.SqlServe (in the DB project, in this case Infrastructure project)
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

**Setup the command line interface and change/update the DB using CLI**

*Note: This isn't mandatory, this is just in case you want to use the CLI to start/drop DB, or to create a migration. Otherwise, the database will be created from the code.*

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
Create a migration - from non-startup project (because DB and API are in a different projects in this case)
```powershell
dotnet ef migrations add "Initial Migration" --startup-project  "../DotNet.IntegrationTesting.Demo3.API"
```


Update a migration in a database (and create a database if doesn't exist)
```powershell
dotnet ef database update
dotnet ef database update "Migration Name"
dotnet ef database update MigrationName
```
Update a migration in a database (and create a database if doesn't exist) - from non-startup project
```powershell
dotnet ef database update --startup-project "../DotNet.IntegrationTesting.Demo3.API"
dotnet ef database update "Initial Migration" --startup-project  "../DotNet.IntegrationTesting.Demo3.API"
```

Remove latest migration
```powershell
dotnet ef migrations remove
```
Remove latest migration - from non-startup project
```powershell
dotnet ef migrations remove --startup-project  "../DotNet.IntegrationTesting.Demo3.API"
```


Drop database
```powershell
dotnet ef database drop
```
Drop database - from non-startup project
```powershell
dotnet ef database drop --startup-project  "../DotNet.IntegrationTesting.Demo3.API"
```
