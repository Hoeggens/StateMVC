//using StateMVC.Models;
//using Microsoft.EntityFrameworkCore;

using StateMVC.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<DataService>();

var app = builder.Build();
app.UseSession();
app.UseRouting();
app.UseEndpoints(o => o.MapControllers());

app.Run();