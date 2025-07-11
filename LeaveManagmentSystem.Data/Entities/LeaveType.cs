﻿using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveManagmentSystem.Data.Entities;

public class LeaveType : BaseEntity
{
    [Column(TypeName = "nvarchar(150)")]
    public string Name { get; set; }    
    public int NumberOfDays {  get; set; }

    public List<LeaveAllocation> LeaveAllocations { get; set; } 
}
