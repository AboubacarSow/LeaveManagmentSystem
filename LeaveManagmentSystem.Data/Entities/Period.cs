namespace LeaveManagmentSystem.Data.Entities;

public class Period :BaseEntity
{
    public string Name { get; set; }
    public DateOnly StartOn { get; set; }
    public DateOnly EndOn { get; set; }
}
