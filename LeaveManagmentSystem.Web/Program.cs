using LeaveManagmentSystem.Application;
using LeaveManagmentSystem.Common.Static;
using LeaveManagmentSystem.Data;
using LeaveManagmentSystem.Data.Extensions;
using Microsoft.AspNetCore.Identity;
using Serilog;


var builder = WebApplication.CreateBuilder(args);


//configuring serilog
builder.Host.UseSerilog((context, config) =>
   config.ReadFrom.Configuration(context.Configuration)
);
// Add services to the container.
builder.Services.AddDatabaseConfiguration(builder.Configuration);
builder.Services.AddApplicationServices(); 
builder.Services.AddHttpContextAccessor();
builder.Services.AddAuthorizationBuilder()
    .AddPolicy("AdminSupervisorOnly", policy => policy.RequireRole(Roles.Administrator, Roles.Supervisor));

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();


builder.Services.AddRouting(opt =>
{
    opt.LowercaseUrls = true;
    opt.LowercaseQueryStrings = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
