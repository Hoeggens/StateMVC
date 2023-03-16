//using StateMVC.Models;
//using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddSession();

var app = builder.Build();

app.UseSession();
app.UseRouting();
app.UseEndpoints(o => o.MapControllers());

app.Run();