using Microsoft.EntityFrameworkCore;
using WebApi.DBOperation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<BookStoreDbContext>(options =>
    options.UseInMemoryDatabase("BookStoreDB"));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Build the app.
var app = builder.Build();

// Initialize data.
using var scope = app.Services.CreateScope();
var serviceProvider = scope.ServiceProvider;
BookRepository.Initialize(serviceProvider);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();