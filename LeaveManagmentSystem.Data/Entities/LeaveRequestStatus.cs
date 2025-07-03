using System.ComponentModel.DataAnnotations;

namespace LeaveManagmentSystem.Data.Entities;

public class LeaveRequestStatus : BaseEntity
{
    [StringLength(50)]
    public string Name { get; set; }
}

