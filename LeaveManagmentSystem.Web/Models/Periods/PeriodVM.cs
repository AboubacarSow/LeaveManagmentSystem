namespace LeaveManagmentSystem.Web.Models.Periods;

public class PeriodVM
{
    public int Id { get; set; }
    public string? Name { get; set; } = string.Empty;
    public DateOnly StartOn { get; set; }
    public DateOnly EndOn { get; set; }
}
