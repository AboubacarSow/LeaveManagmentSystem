using LeaveManagmentSystem.Web.Common;
using LeaveManagmentSystem.Web.Models.LeaveAllocations;
using LeaveManagmentSystem.Web.Services.LeaveAllocations;
using LeaveManagmentSystem.Web.Services.LeaveTypes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


namespace LeaveManagmentSystem.Web.Controllers;

[Authorize]
public class LeaveAllocationController(ILeaveAllocationService _leaveAllocationService, ILeaveTypeService _leaveTypeService) : Controller
{
    [Authorize(Roles = Roles.Administrator)]
    public async Task<IActionResult> Index()
    {
        var employeeVm = await _leaveAllocationService.GetEmployees();
        return View(employeeVm);
    }
    [Authorize(Roles = Roles.Administrator)]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AllocateLeave([FromForm] string? userId)
    {
        await _leaveAllocationService.AllocateLeave(userId);
        return RedirectToAction(nameof(Details), new { userId });
    }
    [Authorize(Roles = Roles.Administrator)]
    [HttpGet]
    public async Task<IActionResult> EditAllocation(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        var allocation = await _leaveAllocationService.GetEmployeeAllocation(id.Value);

        if (allocation == null)
        {
            return NotFound();
        }
        return View(allocation);
    }
    [Authorize(Roles = Roles.Administrator)]
    [HttpPost]
    public async Task<IActionResult> EditAllocation(LeaveAllocationEditVM? allocationVm)
    {
        if(await _leaveTypeService.DaysExceedMaximum(allocationVm.LeaveType.Id, allocationVm.Days))
            ModelState.AddModelError("Days", "The related Allocation exceeds the maximum leave type's days");
        if (!ModelState.IsValid)
        {
            var days= allocationVm.Days;
            allocationVm = await _leaveAllocationService.GetEmployeeAllocation(allocationVm.Id);
            allocationVm.Days= days;
            return View(allocationVm);
        }
        await _leaveAllocationService.EditAllocation(allocationVm);
        return RedirectToAction(nameof(Details), new { userId = allocationVm.Employee?.Id });
    }
    public async Task<IActionResult> Details(string? userId)
    {
        var leaveAllocations = await _leaveAllocationService.GetEmployeeAllocations(userId);
        return View(leaveAllocations);
    }


}
