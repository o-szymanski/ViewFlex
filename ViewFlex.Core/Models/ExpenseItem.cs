namespace ViewFlex.Core.Models;

public class ExpenseItem
{
    public int Id { get; set; }
    public required string Description { get; set; } = string.Empty;
    public required decimal Amount { get; set; }
}
