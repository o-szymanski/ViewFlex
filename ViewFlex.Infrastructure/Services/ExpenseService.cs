using ViewFlex.Core.Interfaces;
using ViewFlex.Core.Models;

namespace ViewFlex.Infrastructure.Services;

public class ExpenseService : IExpenseService
{
    private int _nextExpenseId = 6;
    private const string ExpenseDescription = "Test Expense";

    private readonly List<Expense> Expenses =
    [
        new() { Id = 1, Amount = 100, Description = ExpenseDescription },
        new() { Id = 2, Amount = 100, Description = ExpenseDescription },
        new() { Id = 3, Amount = 100, Description = ExpenseDescription },
        new() { Id = 4, Amount = 100, Description = ExpenseDescription },
        new() { Id = 5, Amount = 100, Description = ExpenseDescription }
    ];

    public async Task<List<Expense>> GetExpensesAsync() => await Task.FromResult(Expenses);

    public async Task AddExpenseAsync(Expense expense)
    {
        if (expense is not null)
        {
            expense.Id = _nextExpenseId++;
            Expenses.Add(expense);
            await Task.CompletedTask;
        }
    }

    public async Task RemoveExpenseAsync(int id)
    {
        var expense = Expenses.FirstOrDefault(x => x.Id == id);
        if (expense is not null) Expenses.Remove(expense);
        await Task.CompletedTask;
    }
}
