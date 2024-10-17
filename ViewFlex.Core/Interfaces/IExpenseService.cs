using ViewFlex.Core.Models;

namespace ViewFlex.Core.Interfaces;

public interface IExpenseService
{
    List<Expense> GetExpenses();
    void AddExpense(Expense expense);
    void RemoveExpense(int id);
}
