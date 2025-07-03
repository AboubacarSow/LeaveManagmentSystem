using AutoMapper;
using LeaveManagmentSystem.Data.Entities;
using LeaveManagmentSystem.Application.Models.LeaveTypes;

namespace LeaveManagmentSystem.Application.AutoMapper;
public class LeaveTypeMapperProfile : Profile
{
    public LeaveTypeMapperProfile()
    {
        CreateMap<LeaveType, LeaveTypeReadOnlyVM>()
            .ForMember(dest => dest.Days, opt => opt.MapFrom(src => src.NumberOfDays));
        CreateMap<LeaveTypeCreateVM, LeaveType>()
            .ForMember(dest => dest.NumberOfDays, opt => opt.MapFrom(src => src.Days));
        CreateMap<LeaveTypeEditVM, LeaveType>()
            .ForMember(dest => dest.NumberOfDays, opt => opt.MapFrom(src => src.Days)).ReverseMap();
    }
}
