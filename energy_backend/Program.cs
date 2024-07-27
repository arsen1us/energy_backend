using energy_backend;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var configurationBuilder = new ConfigurationBuilder();
configurationBuilder.SetBasePath(Directory.GetCurrentDirectory());
configurationBuilder.AddJsonFile("appsettings.json");

var configuration = configurationBuilder.Build();
string connectionString = configuration.GetConnectionString("Default");

builder.Services.AddDbContext<EnergyContext>(options =>
{
    options.UseSqlServer(connectionString);
});

var app = builder.Build();

app.UseHttpsRedirection();

app.UseRouting();

app.UseStaticFiles();

app.MapGet("/", () => "Hello World!");

app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();
