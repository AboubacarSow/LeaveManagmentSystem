using LeaveManagmentSystem.Application.Services.Email;
using LeaveManagmentSystem.Application.Services.LeaveAllocations;
using LeaveManagmentSystem.Application.Services.LeaveRequests;
using LeaveManagmentSystem.Application.Services.LeaveTypes;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace LeaveManagmentSystem.Application;
public static class ApplicationServiceRegister
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddScoped<ILeaveTypeService, LeaveTypeService>();
        services.AddTransient<ILeaveAllocationService, LeaveAllocationService>();
        services.AddTransient<ILeaveRequestService, LeaveRequestService>();
        services.AddTransient<IEmailSender, EmailSender>();
    }
}
