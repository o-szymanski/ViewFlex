using System.Collections.ObjectModel;
using ViewFlex.Core.Interfaces;
using ViewFlex.Core.Models;

namespace ViewFlex.TodoModule.ViewModels;

public class TodoListViewModel : BindableBase
{
    public DelegateCommand AddTodoCommand { get; private set; }
    public DelegateCommand<Todo> DeleteTodoCommand { get; private set; }
    public ObservableCollection<Todo> TodoList { get; set; } = [];

    private readonly ITodoService _todoService;
    private string _newTodoTitle = string.Empty;

    public string NewTodoTitle
    {
        get => _newTodoTitle;
        set => SetProperty(ref _newTodoTitle, value);
    }

    public TodoListViewModel(ITodoService todoService)
    {      
        _todoService = todoService;
        _ = InitializeTodoListAsync();
        AddTodoCommand = new DelegateCommand(async () => await AddTodoAsync());
        DeleteTodoCommand = new DelegateCommand<Todo>(async (todo) => await DeleteTodoAsync(todo));
    }

    public async Task InitializeTodoListAsync()
    {
        var todos = await _todoService.GetTodoListAsync();
        TodoList = new ObservableCollection<Todo>(todos);
    }

    private async Task AddTodoAsync()
    {
        if (!string.IsNullOrEmpty(NewTodoTitle))
        {
            var todo = new Todo { Title = NewTodoTitle };
            await _todoService.AddTodoAsync(todo);
            TodoList.Add(todo);
            NewTodoTitle = string.Empty;
        }
    }

    private async Task DeleteTodoAsync(Todo todo)
    {
        if (todo is not null)
        {
            await _todoService.RemoveTodoAsync(todo.Id);
            TodoList.Remove(todo);
        }
    }
}
