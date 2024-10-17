using System.Collections.ObjectModel;
using ViewFlex.Core.Interfaces;
using ViewFlex.Core.Models;

namespace ViewFlex.ExpensesModule.ViewModels;

public class ExpenseListViewModel : BindableBase
{
    private readonly IExpenseService _expenseService;
    public ObservableCollection<ExpenseItem> ExpenseItems { get; set; }
    public DelegateCommand AddExpenseCommand { get; private set; }

    public ExpenseListViewModel(IExpenseService expenseService)
    {
        _expenseService = expenseService;
        ExpenseItems = new ObservableCollection<ExpenseItem>(_expenseService.GetAllExpenses());
        AddExpenseCommand = new DelegateCommand(AddExpense);
    }

    private void AddExpense()
    {
        var newItem = new ExpenseItem { Description = "New expense", Amount = 0 };
        _expenseService.AddExpenseItem(newItem);
        ExpenseItems.Add(newItem);
    }
}
