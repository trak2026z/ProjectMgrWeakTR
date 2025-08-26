using CarWorkshop.Infrastructure.Extensions;
using CarWorkshop.Infrastructure.Seeders;
using CarWorkshop.Application.Extensions;
using Microsoft.EntityFrameworkCore;
using CarWorkshop.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllersWithViews(options =>
    options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);

builder.Services.AddApplication();

// 🔑 Connection string: ENV > appsettings
var connectionString =
    Environment.GetEnvironmentVariable("ConnectionStrings__DefaultConnection")
    ?? builder.Configuration["ConnectionStrings:DefaultConnection"];

if (string.IsNullOrEmpty(connectionString))
{
    Console.WriteLine("❌ Brak ustawionego connection stringa!");
    throw new InvalidOperationException("Brak ustawionego connection stringa!");
}
else
{
    Console.WriteLine($"✅ Używam connection stringa: {connectionString}");
}

builder.Services.AddDbContext<CarWorkshopDbContext>(options =>
    options.UseNpgsql(connectionString, sql =>
        sql.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null)));

builder.Services.AddScoped<CarWorkshopSeeder>();



// UWAGA: NIE wołamy już AddInfrastructure(builder.Configuration),
// bo ono nadpisuje DbContext!
// Jeśli są tam inne serwisy, rozbij AddInfrastructure na części.

var app = builder.Build();

// Automatyczne migracje + seeding
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<CarWorkshopDbContext>();
    dbContext.Database.Migrate();

    var seeder = scope.ServiceProvider.GetRequiredService<CarWorkshopSeeder>();
    await seeder.Seed();
}

// Middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}



app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();
app.Run();
