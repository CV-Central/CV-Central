using CV_Central.App.Services;
using CV_Central.Context;
using CV_Central.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<UserRepository>();

//Add services to connect at the database
builder.Services.AddDbContext<CVCentralContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.20-mysql")));

/* Configuracion de cookies */
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>{
        options.LoginPath = "/UserAccess/LogIn";
        options.LogoutPath = "/UserAccess/LogOut";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
    });

builder.Services.Configure<Email>(builder.Configuration.GetSection("EmailSettings"));
builder.Services.AddTransient<EmailRepository>();


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

// Evitar caché del navegador
app.Use(async (context, next) =>
{
    context.Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
    context.Response.Headers["Pragma"] = "no-cache";
    context.Response.Headers["Expires"] = "-1";
    await next();
});
/* Autenticación */
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=UserAccess}/{action=LogIn}/{id?}");

app.Run();
