# .NET Unit Testing
.NET Core project that explains/compares several unit testing frameworks, mocking libraries, and other libraries.

## Project structure
- [Src](https://github.com/MTrajK/dotnet-projects/tree/main/DotNet.UnitTestingFrameworks/Src) - Simple demo app used for testing, more info below.
- [Tests](https://github.com/MTrajK/dotnet-projects/tree/main/DotNet.UnitTestingFrameworks/Tests) - There are several projects inside for each framework/library: MSTest, NUnit, XUnit, Moq, NSubstitute, AutoFixture, FluentAssertions.
- [Mock](https://github.com/MTrajK/dotnet-projects/tree/main/DotNet.UnitTestingFrameworks/Mock) - Simple mocking "library" made using Castle.Core DynamicProxy.
- [Docs](https://github.com/MTrajK/dotnet-projects/tree/main/DotNet.UnitTestingFrameworks/Docs) - PowerPoint presentation about this project.

## Demo App
Simple API app that allows creating a user (user's info is saved in JSON file locally) and another API endpoint that allows getting some user's info from a file.
- .NET Core
- Azure Functions
- 3tier Architecture

### Requirement for best experience
Visual Studio installed with Azure Development tool.

### Configuration
- Set as Startup Project -> Src/DotNet.UnitTestingFrameworks.API
- Update the FileStorageLocation property in local.settings.json (Src/DotNet.UnitTestingFrameworks.API) with the path you want to be a local file storage (the user's JSON files will be stored here)

### APIs
- CreateUser
  - http://localhost:7071/api/CreateUser
  - POST method
  - Payload:
    ```JSON
    {
        "FirstName": "Meto",
        "LastName": "Trajkovski",
        "Email": "meto.trajkovski@mail.com",
        "Number1": 49,
        "Number2": 12,
        "Operation": "+"
    }
    ```
- GetUser
  - http://localhost:7071/api/GetUser
  - GET method
  - Payload:
    ```JSON
    {
        "FileName": "User_77bf982a-c4ea-46f1-be7b-749ced4f4d27.json"
    }
    ```
