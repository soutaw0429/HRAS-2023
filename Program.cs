//using HRAS_2023.Data;
using Microsoft.EntityFrameworkCore;
using HRAS.Context;
using HRAS.Interfaces;
using HRAS.Logic;
using HRAS.Services;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ISecurityService, SecurityService>();
builder.Services.AddScoped<IStaffLogic, StaffLogic>();

// Add database connection. This will be the main DB connection when the MSSql middleware connection has been granted
 builder.Services.AddDbContext<AuthDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("HRASTestContext")));
// Use the line above to run the project on Windows machine

// This is the DB connection required for macos. It will be commented out on the repo. Do not remove these lines.
// var serverVersion = new MySqlServerVersion(new Version(10,10,3));
// builder.Services.AddDbContext<AuthDbContext>(options => options.UseMySql(builder.Configuration.GetConnectionString("HRASTestContext"), serverVersion));

// These lines globally configure auth cookies. Do not remove these lines
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>{
    // Cookie settings
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

    options.LoginPath = "/Login/Login";
    options.AccessDeniedPath = "/Login/AccessDenied";
    options.SlidingExpiration = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

// Below Not needed since we can use action in LoginController to start application with Warning page. 
//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Auth}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "login",
    pattern: "{controller=Login}/{action=WarningPage}/{id?}");

app.Run();
