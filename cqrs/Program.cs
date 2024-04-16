using Handler;
using Event;
using Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

// Register your dependencies
builder.Services.AddScoped<CommandHandler>();  // Adjust the lifetime based on your application's needs (Scoped, Singleton, Transient)
builder.Services.AddSingleton<EventStore>();    // Assuming EventStore can be a singleton
builder.Services.AddScoped<AccountRepository>(); // Assuming AccountRepository should be scoped per request

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Map controllers
app.MapControllers();

app.Run();