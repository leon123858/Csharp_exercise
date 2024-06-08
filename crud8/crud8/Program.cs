using crud8;
using Microsoft.EntityFrameworkCore;

var connectionString = "Server=localhost,1433;Database=MyDatabase;User Id=sa;Password=MyPassword123;TrustServerCertificate=True;";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<UserDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddScoped<UserService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<UserDbContext>();
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();