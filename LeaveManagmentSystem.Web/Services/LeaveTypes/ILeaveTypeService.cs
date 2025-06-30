using LeaveManagmentSystem.Web.Models.LeaveTypes;

namespace LeaveManagmentSystem.Web.Services.LeaveTypes
{
    public interface ILeaveTypeService
    {
        Task<bool> CheckifLeaveTypeNameExists(string name);
        Task<bool> CheckifLeaveTypeNameExistsForEdit(LeaveTypeEditVM leaveTypeEdit);
        Task Create(LeaveTypeCreateVM leaveTypeCreate);
        Task Edit(LeaveTypeEditVM leaveTypeedit);
        Task<List<LeaveTypeReadOnlyVM>> GetAllAsync();
        Task<T?> GetByIdAsync<T>(int id);
        bool LeaveTypeExists(int id);
        Task Remove(int id);
    }
}