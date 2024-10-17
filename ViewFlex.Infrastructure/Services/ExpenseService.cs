using ViewFlex.Core.Interfaces;
using ViewFlex.Core.Models;

namespace ViewFlex.Infrastructure.Services;

public class ExpenseService : IExpenseService
{
    private int _nextId = 6;

    private readonly List<Expense> Expenses =
    [
        new() { Id = 1, Amount = 100, Description = "Test Expense" },
        new() { Id = 2, Amount = 100, Description = "Test Expense" },
        new() { Id = 3, Amount = 100, Description = "Test Expense" },
        new() { Id = 4, Amount = 100, Description = "Test Expense" },
        new() { Id = 5, Amount = 100, Description = "Test Expense" }
    ];

    public List<Expense> GetExpenses() => Expenses;

    public void AddExpense(Expense expense)
    {
    if (expense is not null)
        {
            expense.Id = _nextId++;
            Expenses.Add(expense);
        }
    }

    public void RemoveExpense(int id)
    {
        var expense = Expenses.FirstOrDefault(x => x.Id == id);
        if (expense is not null) Expenses.Remove(expense);
    }
}
