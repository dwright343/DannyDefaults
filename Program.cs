using DannyDefaults.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DannyDefaultsIdentityDbContextConnection") ?? throw new InvalidOperationException("Connection string 'DannyDefaultsIdentityDbContextConnection' not found.");

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddCors(); //cross origin resource sharing

builder.Services.AddDbContext<Default_Context>(options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"]);
}
);

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<DannyDefaultsIdentityDbContext>();

builder.Services.AddScoped<I_Repository, EF_Repository>();

builder.Services.AddRazorPages();

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();

builder.Services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

// Add builder.Services above this line
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseCors(p => p.WithOrigins("http://localhost:3000"));

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseSession();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute("pagenumanddefaultletter", "{defaultLetter}/{pageNum}", new { Controller = "Home", action = "Index" });
app.MapControllerRoute("pagination", "Stuff/{pageNum}", new { Controller = "Home", action = "Index", pageNum = 1 });
app.MapControllerRoute("defaultLetter", "{defaultLetter}", new { Controller = "Home", action = "Index", pageNum = 1 });

app.MapRazorPages();

app.MapDefaultControllerRoute();

app.Run();
