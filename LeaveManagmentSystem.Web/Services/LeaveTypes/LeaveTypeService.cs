using AutoMapper;
using LeaveManagmentSystem.Web.Data;
using LeaveManagmentSystem.Web.Data.Entities;
using LeaveManagmentSystem.Web.Data.Migrations;
using LeaveManagmentSystem.Web.Models.LeaveTypes;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace LeaveManagmentSystem.Web.Services.LeaveTypes;

public class LeaveTypeService : ILeaveTypeService
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public LeaveTypeService(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<LeaveTypeReadOnlyVM>> GetAllAsync()
    {
        var leaveTypes = await _context.LeaveTypes.ToListAsync();

        var viewData = _mapper.Map<List<LeaveTypeReadOnlyVM>>(leaveTypes);
        return viewData;
    }

    public async Task<T?> GetByIdAsync<T>(int id)
    {
        var leaveType = await _context.LeaveTypes.FirstOrDefaultAsync(l => l.Id.Equals(id));
        if (leaveType == null) return default;
        var viewdata = _mapper.Map<T>(leaveType);
        return viewdata;
    }

    public async Task Remove(int id)
    {
        var leaveType = await _context.LeaveTypes.FirstOrDefaultAsync(l => l.Id.Equals(id));
        if (leaveType is not null)
        {
            _context.LeaveTypes.Remove(leaveType);
            await _context.SaveChangesAsync();
        }
    }
    public async Task Edit(LeaveTypeEditVM leaveTypeedit)
    {
        var data = _mapper.Map<LeaveType>(leaveTypeedit);
        _context.Update(data);
        await _context.SaveChangesAsync();
    }
    public async Task Create(LeaveTypeCreateVM leaveTypeCreate)
    {
        var data = _mapper.Map<LeaveType>(leaveTypeCreate);
        _context.Add(data);
        await _context.SaveChangesAsync();
    }

    public bool LeaveTypeExists(int id)
    {
        return _context.LeaveTypes.Any(e => e.Id == id);
    }
    public async Task<bool> CheckifLeaveTypeNameExists(string name)
    {
        var lowername = name.ToLower();
        return await _context.LeaveTypes.AnyAsync(l => l.Name.ToLower().Equals(lowername));
    }
    public async Task<bool> CheckifLeaveTypeNameExistsForEdit(LeaveTypeEditVM leaveTypeEdit)
    {
        var lowername = leaveTypeEdit.Name.ToLower();
        return await _context.LeaveTypes.AnyAsync(l => l.Name.ToLower().Equals(lowername)
        && l.Id != leaveTypeEdit.Id);
    }
}
