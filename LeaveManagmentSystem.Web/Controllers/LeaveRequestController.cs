using LeaveManagmentSystem.Web.Common;
using LeaveManagmentSystem.Web.Models.LeaveRequests;
using LeaveManagmentSystem.Web.Services.LeaveRequests;
using LeaveManagmentSystem.Web.Services.LeaveTypes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;

namespace LeaveManagmentSystem.Web.Controllers;
[Authorize]
public class LeaveRequestController(ILeaveTypeService _leaveTypeServe,
    ILeaveRequestService _leaveRequestService) : Controller
{
    public async Task<IActionResult> Index()
    {
        var modelVm = await _leaveRequestService.GetEmployeeLeaveRequests();
        return View(modelVm);
    }
    [HttpGet]
    public async Task<IActionResult> Create(int? leaveTypeId)
    {
        var leaveTypes = await _leaveTypeServe.GetAllAsync();
        var leaveTypesList = new SelectList(leaveTypes, "Id", "Name",leaveTypeId);
        var model = new LeaveRequestCreateVM
        {
            StartDate = DateOnly.FromDateTime(DateTime.Now),
            EndDate = DateOnly.FromDateTime(DateTime.Now.AddDays(1)),
            LeaveTypes = leaveTypesList,
        };
        return View(model);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(LeaveRequestCreateVM model)
    {
        if(await _leaveRequestService.RequestDatesExceedAllocation(model))
        {
            ModelState.AddModelError(string.Empty, "You have exceeded your allocation");
            ModelState.AddModelError(nameof(model.EndDate), "The number of days requested is invalid. ");
        }
        if (!ModelState.IsValid)
        {
            var leaveTypes = await _leaveTypeServe.GetAllAsync();
            model.LeaveTypes= new SelectList(leaveTypes, "Id", "Name");
            return View(model);
        }
        await _leaveRequestService.CreateLeaveRequest(model);
        return RedirectToAction(nameof(Details),nameof(LeaveAllocation));
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Cancel(int id)
    {
        await _leaveRequestService.CancelLeaveRequest(id);
        return RedirectToAction(nameof(Index));
    }
    [Authorize(Policy = "AdminSupervisorOnly")]
    public async Task<IActionResult> ListRequests()
    {
        var modelVm = await _leaveRequestService.AdminGetAllLeaveRequests();
        return View(modelVm);
    }
    [Authorize(Roles =Roles.Administrator)]
    [HttpGet]
    public async Task<IActionResult> Review(int id)
    {
        var model = await _leaveRequestService.GetLeaveRequestForReview(id);
        return View(model);
    }
    [Authorize(Roles = Roles.Administrator)]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Review(int id, bool approved)
    {
        await _leaveRequestService.ReviewLeaveRequest(id, approved);
        return RedirectToAction(nameof(ListRequests));
    }
}
