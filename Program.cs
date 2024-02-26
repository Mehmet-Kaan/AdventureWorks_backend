// Importing necessary namespaces
global using AdventureWorks_backend.Models;
global using AdventureWorks_backend.Services.PersonService;
global using AdventureWorks_backend.Dtos.Person;
global using AdventureWorks_backend.Models.Person;
global using AutoMapper;
global using Microsoft.EntityFrameworkCore;
global using AdventureWorks_backend.Data;
using Microsoft.Data.Sqlite;

// Create a new WebApplication instance
var builder = WebApplication.CreateBuilder(args);

// Configure the database context
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Add controllers to the service container
builder.Services.AddControllers();

// Configure CORS (Cross-Origin Resource Sharing)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

// Add API Explorer
builder.Services.AddEndpointsApiExplorer();

// Add Swagger generation
builder.Services.AddSwaggerGen();

// Add AutoMapper
builder.Services.AddAutoMapper(typeof(Program).Assembly);

// Add scoped PersonService
builder.Services.AddScoped<IPersonService, PersonService>();

// Build the application
var app = builder.Build();

// Execute SQL script during application startup if in development mode
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Enable HTTPS redirection
app.UseHttpsRedirection();

// Enable authorization
app.UseAuthorization();

// Enable CORS middleware
app.UseCors("AllowAllOrigins");

// Map controllers
app.MapControllers();

// Run the application
app.Run();

// Method to execute SQL script
// void ExecuteSqlScript(string connectionString)
// {
//     try
//     {
//         // Read SQL script file
//         string scriptPath = "DatabaseScripts/Persons.sqlite";
//         string scriptContent = File.ReadAllText(scriptPath);

//         // Connect to the database and execute the script
//         using (var connection = new SqliteConnection(connectionString))
//         {
//             connection.Open();
//             using (var command = connection.CreateCommand())
//             {
//                 command.CommandText = scriptContent;
//                 command.ExecuteNonQuery();
//             }
//         }
//     }
//     catch (Exception ex)
//     {
//         // Handle exception
//         Console.WriteLine("Error executing SQL script: " + ex.Message);
//     }
// }
