using ViewFlex.Core.Interfaces;
using ViewFlex.Core.Models;

namespace ViewFlex.Infrastructure.Services;

public class ExpenseService : IExpenseService
{
    private readonly List<ExpenseItem> _expenseItems = [new ExpenseItem { Id = 1, Amount = 100, Description = "Orange Internet" }, new ExpenseItem { Id = 2, Amount = 30, Description = "Amazon Prime Subscription" }];
    public List<ExpenseItem> GetAllExpenses() => _expenseItems;
    public void AddExpenseItem(ExpenseItem item) => _expenseItems.Add(item);
    public void RemoveExpenseItem(int id)
    {
        var item = _expenseItems.FirstOrDefault(x => x.Id == id);
        if (item != null) _expenseItems.Remove(item);
    }
}
