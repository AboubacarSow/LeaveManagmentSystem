using LeaveManagmentSystem.Web.Services.LeaveAllocations;
using Microsoft.AspNetCore.Mvc;


namespace LeaveManagmentSystem.Web.Controllers;

public class LeaveAllocationController(ILeaveAllocationService _leaveAllocationService) : Controller
{
    public async Task<IActionResult> Details()
    {
        var leaveAllocations= await _leaveAllocationService.GetEmployeeAllocations();
        return View(leaveAllocations);
    }
}
