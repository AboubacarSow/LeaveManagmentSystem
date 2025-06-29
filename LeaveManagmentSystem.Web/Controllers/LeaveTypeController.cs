using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LeaveManagmentSystem.Web.Data;
using LeaveManagmentSystem.Web.Data.Entities;
using LeaveManagmentSystem.Web.Models.LeaveTypes;
using AutoMapper;

namespace LeaveManagmentSystem.Web.Controllers
{
    public class LeaveTypeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private const string NameAlreadyExistsMessage = "This leave type already exists in the database";

        public LeaveTypeController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: LeaveType
        public async Task<IActionResult> Index()
        {
            var data = await _context.LeaveTypes.ToListAsync();
           var viewData=_mapper.Map<List<LeaveTypeReadOnlyVM>>(data);
            return View(viewData);
        }

        // GET: LeaveType/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaveType = await _context.LeaveTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (leaveType == null)
            {
                return NotFound();
            }
            var viewdata=_mapper.Map<LeaveTypeReadOnlyVM>(leaveType);   
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
                if(await CheckifLeaveTypeNameExists(leaveType.Name))
                {
                    ModelState.AddModelError(nameof(leaveType.Name), NameAlreadyExistsMessage);
                    return View(leaveType);
                }
                var data= _mapper.Map<LeaveType>(leaveType);
                _context.Add(data);
                await _context.SaveChangesAsync();
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

            var leaveType = await _context.LeaveTypes.FindAsync(id);
            if (leaveType == null)
            {
                return NotFound();
            }
            var viewdata=_mapper.Map<LeaveTypeEditVM>(leaveType);
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
                    if (await CheckifLeaveTypeNameExistsForEdit(leaveType))
                    {
                        ModelState.AddModelError(nameof(leaveType.Name), NameAlreadyExistsMessage);
                        return View(leaveType);
                    }
                    var data = _mapper.Map<LeaveType>(leaveType);
                    _context.Update(data);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeaveTypeExists(leaveType.Id))
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

            var leaveType = await _context.LeaveTypes
                .FirstOrDefaultAsync(m => m.Id == id);
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
            var leaveType = await _context.LeaveTypes.FindAsync(id);
            if (leaveType != null)
            {
                _context.LeaveTypes.Remove(leaveType);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LeaveTypeExists(int id)
        {
            return _context.LeaveTypes.Any(e => e.Id == id);
        }
        private async Task<bool> CheckifLeaveTypeNameExists(string name)
        {
            var lowername=name.ToLower();
            return await _context.LeaveTypes.AnyAsync(l => l.Name.ToLowerInvariant().Equals(lowername));
        }
        private async Task<bool> CheckifLeaveTypeNameExistsForEdit(LeaveTypeEditVM leaveTypeEdit)
        {
            var lowername = leaveTypeEdit.Name.ToLower();
            return await _context.LeaveTypes.AnyAsync(l => l.Name.ToLowerInvariant().Equals(lowername)
            && l.Id!=leaveTypeEdit.Id);
        }
    }
}
