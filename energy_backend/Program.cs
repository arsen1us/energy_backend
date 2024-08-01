using energy_backend;
using energy_backend.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var configurationBuilder = new ConfigurationBuilder();
configurationBuilder.SetBasePath(Directory.GetCurrentDirectory());
configurationBuilder.AddJsonFile("appsettings.json");

var configuration = configurationBuilder.Build();
string connectionString = configuration.GetConnectionString("Default");

builder.Services.AddCors(options =>
{
    options.AddPolicy("default", policy =>
    {
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
        policy.AllowAnyOrigin();
    });
});

builder.Services.AddDbContext<EnergyContext>(options =>
{
    options.UseSqlServer(connectionString);
});
builder.Services.AddTransient<IUserService, UserService>();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseRouting();

app.UseStaticFiles();

app.UseCors("default");

app.MapGet("/{id}", (string id) => $"Hello World! id - {id}");

app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();
