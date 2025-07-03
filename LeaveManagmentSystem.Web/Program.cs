using LeaveManagmentSystem.Web.Common;
using LeaveManagmentSystem.Web.Data;
using LeaveManagmentSystem.Web.Data.Entities;
using LeaveManagmentSystem.Web.Services.Email;
using LeaveManagmentSystem.Web.Services.LeaveAllocations;
using LeaveManagmentSystem.Web.Services.LeaveRequests;
using LeaveManagmentSystem.Web.Services.LeaveTypes;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? 
    throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddScoped<ILeaveTypeService, LeaveTypeService>();  
builder.Services.AddTransient<ILeaveAllocationService, LeaveAllocationService>(); 
builder.Services.AddTransient<ILeaveRequestService, LeaveRequestService>(); 
builder.Services.AddTransient<IEmailSender, EmailSender>(); 
builder.Services.AddHttpContextAccessor();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddAuthorization(opt =>
{
    opt.AddPolicy("AdminSupervisorOnly", policy => policy.RequireRole(Roles.Administrator, Roles.Supervisor));

});

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
