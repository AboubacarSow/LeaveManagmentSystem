using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LeaveManagmentSystem.Web.Models.LeaveTypes;
using Microsoft.AspNetCore.Authorization;
using LeaveManagmentSystem.Web.Services.LeaveTypes;

namespace LeaveManagmentSystem.Web.Controllers;


[Authorize(Roles ="Administrator")]
public class LeaveTypeController(ILeaveTypeService leaveTypeService) : Controller
{
   
    private const string NameAlreadyExistsMessage = "This leave type already exists in the database";

  

    // GET: LeaveType
    public async Task<IActionResult> Index()
    {
       var viewData= await leaveTypeService.GetAllAsync();
        return View(viewData);
    }

    // GET: LeaveType/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        int index=id.Value;
        var viewdata = await leaveTypeService.GetByIdAsync<LeaveTypeReadOnlyVM>(index);
        if (viewdata == null)
        {
            return NotFound();
        }
        ;   
        return View(viewdata);
    }

    // GET: LeaveType/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: LeaveType/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Name,Days")] LeaveTypeCreateVM leaveType)
    {
        if (ModelState.IsValid)
        {
            if(await leaveTypeService.CheckifLeaveTypeNameExists(leaveType.Name))
            {
                ModelState.AddModelError(nameof(leaveType.Name), NameAlreadyExistsMessage);
                return View(leaveType);
            }
           await leaveTypeService.Create(leaveType);
            return RedirectToAction(nameof(Index));
        }
        return View(leaveType);
    }


    // GET: LeaveType/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        var viewdata = await leaveTypeService.GetByIdAsync<LeaveTypeEditVM>(id.Value);
        if (viewdata == null)
        {
            return NotFound();
        }
        return View(viewdata);
    }

    // POST: LeaveType/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Days")] LeaveTypeEditVM leaveType)
    {
        if (id != leaveType.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                if (await leaveTypeService.CheckifLeaveTypeNameExistsForEdit(leaveType))
                {
                    ModelState.AddModelError(nameof(leaveType.Name), NameAlreadyExistsMessage);
                    return View(leaveType);
                }
               await leaveTypeService.Edit(leaveType);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!leaveTypeService.LeaveTypeExists(leaveType.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(leaveType);
    }


    // GET: LeaveType/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        var leaveType = await leaveTypeService.GetByIdAsync<LeaveTypeReadOnlyVM>(id.Value);
        if (leaveType == null)
        {
            return NotFound();
        }

        return View(leaveType);
    }

    // POST: LeaveType/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
       await leaveTypeService.Remove(id);
        return RedirectToAction(nameof(Index));
    }

    
}
