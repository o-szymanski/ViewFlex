namespace ViewFlex.Core.Models;

public class TodoItem
{
    public int Id { get; set; }
    public required string Title { get; set; } = string.Empty;
    public required bool IsCompleted { get; set; }
}
