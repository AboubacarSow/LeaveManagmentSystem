namespace LeaveManagmentSystem.Web.Data.Entities;

public class Period :BaseEntity
{
    public string Name { get; set; }
    public DateOnly StartOn { get; set; }
    public DateOnly EndOn { get; set; }
}
