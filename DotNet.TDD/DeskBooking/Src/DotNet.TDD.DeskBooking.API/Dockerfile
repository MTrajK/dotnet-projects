#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Src/DotNet.TDD.DeskBooking.API/DotNet.TDD.DeskBooking.API.csproj", "Src/DotNet.TDD.DeskBooking.API/"]
COPY ["Src/DotNet.TDD.DeskBooking.Application/DotNet.TDD.DeskBooking.Application.csproj", "Src/DotNet.TDD.DeskBooking.Application/"]
COPY ["Src/DotNet.TDD.DeskBooking.Domain/DotNet.TDD.DeskBooking.Domain.csproj", "Src/DotNet.TDD.DeskBooking.Domain/"]
COPY ["Src/DotNet.TDD.DeskBooking.Infrastructure/DotNet.TDD.DeskBooking.Infrastructure.csproj", "Src/DotNet.TDD.DeskBooking.Infrastructure/"]
RUN dotnet restore "Src/DotNet.TDD.DeskBooking.API/DotNet.TDD.DeskBooking.API.csproj"
COPY . .
WORKDIR "/src/Src/DotNet.TDD.DeskBooking.API"
RUN dotnet build "DotNet.TDD.DeskBooking.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DotNet.TDD.DeskBooking.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DotNet.TDD.DeskBooking.API.dll"]