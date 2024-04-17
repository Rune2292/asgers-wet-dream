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
builder.Services.AddSingleton<HistoryModel>();
builder.Services.AddSingleton<HistoryConsumer>();



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
var historyConsumer = app.Services.GetRequiredService<OverviewConsumer>();
var overviewConsumer = app.Services.GetRequiredService<HistoryConsumer>();

app.MapControllers();

app.Run();