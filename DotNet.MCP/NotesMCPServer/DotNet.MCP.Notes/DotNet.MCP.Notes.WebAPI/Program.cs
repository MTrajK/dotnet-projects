using DotNet.MCP.Notes.Application;
using DotNet.MCP.Notes.Infrastructure;
using DotNet.MCP.Notes.Infrastructure.Persistence;

using Microsoft.OpenApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(swagger =>
{
    swagger.SwaggerDoc("v1", new OpenApiInfo { Title = "Notes", Version = "v1" });
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("BlazorClient", policy =>
    {
        policy.WithOrigins("https://localhost:7100", "http://localhost:5100")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(swagger => swagger.SwaggerEndpoint("/swagger/v1/swagger.json", "Notes v1"));
}

app.UseHttpsRedirection();
app.UseCors("BlazorClient");

app.MapControllers();

app.Services.EnsureDatabaseCreated();

app.Run();