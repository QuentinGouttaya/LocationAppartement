using GSBAppartement.Repository.Interfaces;
using GSBAppartement.Repository.Implementations;
using GSBAppartement.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

// Register the DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:5173",
                                              "https://localhost:5173").AllowAnyHeader().AllowAnyMethod();
                      });
});


// Register the repository
builder.Services.AddScoped<IAppartementRepository, AppartementRepository>();
builder.Services.AddScoped<IProprietaireRepository, ProprietaireRepository>();
builder.Services.AddScoped<ILocataireRepository, LocataireRepository>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();

var app = builder.Build();

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var context = services.GetRequiredService<ApplicationDbContext>();
try
{
    context.Database.CanConnect();
    Console.WriteLine("Database connection successful.");
}
catch (Exception ex)
{
    Console.WriteLine($"Error connecting to database: {ex.Message}");
}




app.UseCors(MyAllowSpecificOrigins);
app.MapControllers();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Other middleware and endpoint configuration...

app.Run();
