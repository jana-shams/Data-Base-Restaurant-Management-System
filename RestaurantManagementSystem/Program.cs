using Microsoft.EntityFrameworkCore;
using RestaurantManagementSystem.Data;
using RestaurantManagementSystem.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using RestaurantManagementSystem.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Add DbContext
builder.Services.AddDbContext<RestaurantManagementContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("RestaurantManagementConnection")));

// Add HttpContextAccessor service
builder.Services.AddHttpContextAccessor();

// Add the User service
builder.Services.AddScoped<UserService>();

// Add Session Services
builder.Services.AddSession();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login";
        options.AccessDeniedPath = "/Login";
    });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();

app.UseAuthorization();
app.UseSession();

app.MapRazorPages();
app.MapGet("/", () => Results.Redirect("/Login"));

// Seed the database
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<RestaurantManagementContext>();
    DataInitializer.Initialize(context).Wait();
}

app.Run();