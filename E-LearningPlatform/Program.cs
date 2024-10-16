using E_LearningPlatform.Context;
using E_LearningPlatform.DataAccess.Context;
using E_LearningPlatform.DataAccess.Repository;
using E_LearningPlatform.DataAccess.Repository.IRepository;
using E_LearningPlatform.Models;
using E_LearningPlatform.Utility.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDbContext<AccountDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IRepository<User>,Repository<User>>();
builder.Services.AddScoped<IGenericService<User>,GenericService<User>>();
builder.Services.AddIdentity<Account,IdentityRole>().AddEntityFrameworkStores<AccountDbContext>();
builder.Services.ConfigureApplicationCookie(option=>
{
    option.LoginPath = "/Account/Login";
    option.AccessDeniedPath = "/Account/AccessDenied";

});
// Add services to the container.
builder.Services.AddControllersWithViews();
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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
