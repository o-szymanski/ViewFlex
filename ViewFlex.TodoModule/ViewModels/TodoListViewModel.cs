using System.Collections.ObjectModel;
using ViewFlex.Core.Interfaces;
using ViewFlex.Core.Models;

namespace ViewFlex.TodoModule.ViewModels;

public class TodoListViewModel : BindableBase
{
    private readonly ITodoService _todoService;
    public ObservableCollection<TodoItem> TodoItems { get; set; }
    public DelegateCommand AddTodoCommand { get; private set; }

    public TodoListViewModel(ITodoService todoService)
    {
        _todoService = todoService;
        TodoItems = new ObservableCollection<TodoItem>(_todoService.GetAllTodos());
        AddTodoCommand = new DelegateCommand(AddTodo);
    }

    private void AddTodo()
    {
        var newItem = new TodoItem { Title = "New task", IsCompleted = false };
        _todoService.AddTodoItem(newItem);
        TodoItems.Add(newItem);
    }
}
