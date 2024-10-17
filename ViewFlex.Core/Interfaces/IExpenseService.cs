using ViewFlex.Core.Models;

namespace ViewFlex.Core.Interfaces;

public interface IExpenseService
{
    List<ExpenseItem> GetAllExpenses();
    void AddExpenseItem(ExpenseItem item);
    void RemoveExpenseItem(int id);
}
