using System.Collections.ObjectModel;
using ViewFlex.Core.Interfaces;
using ViewFlex.Core.Models;
using ViewFlex.Infrastructure.Services;

namespace ViewFlex.ExpensesModule.ViewModels;

public class ExpenseListViewModel : BindableBase
{ 
    public ObservableCollection<Expense> Expenses { get; set; } = [];
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
        _ = InitializeExpensesAsync();
        AddExpenseCommand = new DelegateCommand(async () => await AddExpenseAsync());
        DeleteExpenseCommand = new DelegateCommand<Expense>(async (expense) => await DeleteExpenseAsync(expense));
    }

    public async Task InitializeExpensesAsync()
    {
        var expenses = await _expenseService.GetExpensesAsync();
        Expenses = new ObservableCollection<Expense>(expenses);
    }

    private async Task AddExpenseAsync()
    {
        if (!string.IsNullOrEmpty(NewExpenseDescription) && NewExpenseAmount > MinimumExpenseAmount)
        {
            var expense = new Expense { Description = NewExpenseDescription, Amount = NewExpenseAmount };
            await _expenseService.AddExpenseAsync(expense);
            Expenses.Add(expense);

            NewExpenseDescription = string.Empty;
            NewExpenseAmount = MinimumExpenseAmount;
        }
    }

    private async Task DeleteExpenseAsync(Expense expense)
    {
        if (expense is not null)
        {
            await _expenseService.RemoveExpenseAsync(expense.Id);
            Expenses.Remove(expense);
        }
    }
}
