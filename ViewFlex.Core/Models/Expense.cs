namespace ViewFlex.Core.Models;

public class Expense
{
    public int Id { get; set; }
    public required string Description { get; set; } = string.Empty;
    public required decimal Amount { get; set; }
}
