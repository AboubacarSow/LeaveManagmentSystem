using System.ComponentModel.DataAnnotations;

namespace LeaveManagmentSystem.Web.Data.Entities;

public class LeaveRequestStatus : BaseEntity
{
    [StringLength(50)]
    public string Name { get; set; }
}

