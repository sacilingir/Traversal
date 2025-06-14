using Microsoft.EntityFrameworkCore;
using SignalRApi.DAL;
using SignalRApi.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<VisitorService>();
builder.Services.AddSignalR();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<Context>(options =>
    options.UseNpgsql(connectionString));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
