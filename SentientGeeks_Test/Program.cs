using Intigators.SentientGeeks_Test;
using Microsoft.EntityFrameworkCore;
using MyApp.db.MydbContext;

var builder = intigators.Interfaceregister(WebApplication.CreateBuilder(args));


// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddDbContextPool<AppdbContext>(options =>
          options.UseSqlServer(builder.Configuration.GetConnectionString("ServerConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseCors("EnableCORS");
app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
