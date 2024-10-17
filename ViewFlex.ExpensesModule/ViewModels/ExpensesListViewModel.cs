using System.Collections.ObjectModel;
using ViewFlex.Core.Interfaces;
using ViewFlex.Core.Models;

namespace ViewFlex.ExpensesModule.ViewModels;

public class ExpenseListViewModel : BindableBase
{ 
    public ObservableCollection<ExpenseItem> ExpenseItems { get; set; }
    public DelegateCommand<ExpenseItem> DeleteExpenseCommand { get; private set; }
    public DelegateCommand AddExpenseCommand { get; private set; }

    private readonly IExpenseService _expenseService;
    private string _newExpenseDescription = string.Empty;
    private decimal _newExpenseAmount;

    public string NewExpenseDescription
    {
        get => _newExpenseDescription;
        set => SetProperty(ref _newExpenseDescription, value);
    }
  
    public decimal NewExpenseAmount
    {
        get => _newExpenseAmount;
        set => SetProperty(ref _newExpenseAmount, value);
    }

    public ExpenseListViewModel(IExpenseService expenseService)
    {
        _expenseService = expenseService;
        ExpenseItems = new ObservableCollection<ExpenseItem>(_expenseService.GetAllExpenses());
        AddExpenseCommand = new DelegateCommand(AddExpense);
        DeleteExpenseCommand = new DelegateCommand<ExpenseItem>(DeleteExpense);
    }

    private void AddExpense()
    {
        if (!string.IsNullOrEmpty(NewExpenseDescription) && NewExpenseAmount > 0)
        {
            var newItem = new ExpenseItem { Description = NewExpenseDescription, Amount = NewExpenseAmount };
            _expenseService.AddExpenseItem(newItem);
            ExpenseItems.Add(newItem);

            NewExpenseDescription = string.Empty;
            NewExpenseAmount = 0;
        }
    }

    private void DeleteExpense(ExpenseItem item)
    {
        if (item is not null)
        {
            _expenseService.RemoveExpenseItem(item.Id);
            ExpenseItems.Remove(item);
        }
    }
}
