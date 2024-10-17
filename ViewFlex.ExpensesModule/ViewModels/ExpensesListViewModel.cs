using System.Collections.ObjectModel;
using ViewFlex.Core.Interfaces;
using ViewFlex.Core.Models;

namespace ViewFlex.ExpensesModule.ViewModels;

public class ExpenseListViewModel : BindableBase
{ 
    public ObservableCollection<Expense> Expenses { get; set; }
    public DelegateCommand<Expense> DeleteExpenseCommand { get; private set; }
    public DelegateCommand AddExpenseCommand { get; private set; }

    private readonly IExpenseService _expenseService;
    private string _newExpenseDescription = string.Empty;
    private decimal _newExpenseAmount;

    private const decimal MinimumExpenseAmount = 0;

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
        Expenses = new ObservableCollection<Expense>(_expenseService.GetExpenses());
        AddExpenseCommand = new DelegateCommand(AddExpense);
        DeleteExpenseCommand = new DelegateCommand<Expense>(DeleteExpense);
    }

    private void AddExpense()
    {
        if (!string.IsNullOrEmpty(NewExpenseDescription) && NewExpenseAmount > MinimumExpenseAmount)
        {
            var expense = new Expense { Description = NewExpenseDescription, Amount = NewExpenseAmount };
            _expenseService.AddExpense(expense);
            Expenses.Add(expense);

            NewExpenseDescription = string.Empty;
            NewExpenseAmount = MinimumExpenseAmount;
        }
    }

    private void DeleteExpense(Expense expense)
    {
        if (expense is not null)
        {
            _expenseService.RemoveExpense(expense.Id);
            Expenses.Remove(expense);
        }
    }
}
