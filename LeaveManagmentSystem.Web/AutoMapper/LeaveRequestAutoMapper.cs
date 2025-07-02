using AutoMapper;
using LeaveManagmentSystem.Web.Models.LeaveRequests;

namespace LeaveManagmentSystem.Web.AutoMapper;

public class LeaveRequestAutoMapper : Profile
{
    public LeaveRequestAutoMapper()
    {
        CreateMap<LeaveRequestCreateVM, LeaveRequest>();
    }
}
