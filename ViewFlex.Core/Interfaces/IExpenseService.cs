using ViewFlex.Core.Models;

namespace ViewFlex.Core.Interfaces;

public interface IExpenseService
{
    Task<List<Expense>> GetExpensesAsync();
    Task AddExpenseAsync(Expense expense);
    Task RemoveExpenseAsync(int id);
}
