//using HRAS_2023.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using HRAS.Context;
using HRAS.Interfaces;
using HRAS.Repository;
using HRAS.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ISecurityService, SecurityService>();
builder.Services.AddScoped<ISearchService, SearchService>();
builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<IStaffRepository, StaffRepository>();

// Add database connection
builder.Services.AddDbContext<HRASContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("HRASContext")));
// builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<HRASContext>();

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

app.UseAuthorization();

// Below Not needed since we can use action in LoginController to start application with Warning page. 
//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Auth}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "login",
    pattern: "{controller=Login}/{action=WarningPage}/{id?}");

app.Run();

