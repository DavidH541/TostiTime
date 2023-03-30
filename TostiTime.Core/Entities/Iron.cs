namespace TostiTime.Core.Entities;

public class Iron : EntityBase
{
    public string Name { get; set; } = string.Empty;
    public Office? Office { get; set; }
    public int OfficeId { get; set; }
    public List<Slot> Slots { get; set; } = new List<Slot>();
    public int NumberOfSlots => Slots.Count;
}