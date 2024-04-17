using Handler;
using Event;
using ReadModel;
using Repository;
using Consumer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

// Register your dependencies
builder.Services.AddScoped<CommandHandler>();
builder.Services.AddSingleton<EventStore>();
builder.Services.AddScoped<AccountRepository>();
builder.Services.AddSingleton<OverviewModel>();
builder.Services.AddSingleton<OverviewConsumer>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

// Subscribe the consumer to the event store
var eventStore = app.Services.GetRequiredService<EventStore>();
var consumer = app.Services.GetRequiredService<OverviewConsumer>();

app.MapControllers();

app.Run();