using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using VitzShop.Infrastructure.Data;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation;
using VitzShop.Infrastructure;
using VitzShop.Application;

var builder = WebApplication.CreateBuilder(args);

var adminPassword = builder.Configuration["TestAdmin:AdminPassword"];

builder.Services.AddRazorPages()
        .AddRazorRuntimeCompilation();
builder.Services.AddHttpContextAccessor();

builder.Services.AddApplicationLayerServices();
builder.Services.AddInfrastructureServices(builder.Configuration);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    try
    {
        db.Database.EnsureCreated();
        Console.WriteLine("-Применение миграции БД...");
        db.Database.Migrate();
        Console.WriteLine("-Миграции БД применены успешно.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"-Миграции БД применены с ошибками: {ex.Message}");
    }
}

if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();
app.MapRazorPages();

app.Run();
