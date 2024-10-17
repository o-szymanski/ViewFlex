using ViewFlex.Core.Interfaces;
using ViewFlex.Core.Models;

namespace ViewFlex.Infrastructure.Services;

public class ExpenseService : IExpenseService
{
    private int _nextId = 6;
    private readonly List<ExpenseItem> _expenseItems =
    [
        new() { Id = 1, Amount = 100, Description = "Test Expense" },
        new() { Id = 2, Amount = 100, Description = "Test Expense" },
        new() { Id = 3, Amount = 100, Description = "Test Expense" },
        new() { Id = 4, Amount = 100, Description = "Test Expense" },
        new() { Id = 5, Amount = 100, Description = "Test Expense" }
    ];

    public List<ExpenseItem> GetAllExpenses() => _expenseItems;

    public void AddExpenseItem(ExpenseItem item)
    {
    if (item is not null)
        {
            item.Id = _nextId++;
            _expenseItems.Add(item);
        }
    }

    public void RemoveExpenseItem(int id)
    {
        var item = _expenseItems.FirstOrDefault(x => x.Id == id);
        if (item is not null) _expenseItems.Remove(item);
    }
}
