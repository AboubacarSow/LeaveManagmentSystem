using AutoMapper;
using LeaveManagmentSystem.Data.Entities;
using LeaveManagmentSystem.Application.Models.LeaveRequests;

namespace LeaveManagmentSystem.Application.AutoMapper;

public class LeaveRequestAutoMapper : Profile
{
    public LeaveRequestAutoMapper()
    {
        CreateMap<LeaveRequestCreateVM, LeaveRequest>();
    }
}
