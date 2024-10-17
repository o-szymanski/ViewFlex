using System.Collections.ObjectModel;
using ViewFlex.Core.Interfaces;
using ViewFlex.Core.Models;

namespace ViewFlex.TodoModule.ViewModels;

public class TodoListViewModel : BindableBase
{
    public DelegateCommand AddTodoCommand { get; private set; }
    public DelegateCommand<TodoItem> DeleteTodoCommand { get; private set; }
    public ObservableCollection<TodoItem> TodoItems { get; set; }

    private readonly ITodoService _todoService;
    private string _newTaskTitle = string.Empty;

    public string NewTaskTitle
    {
        get => _newTaskTitle;
        set => SetProperty(ref _newTaskTitle, value);
    }

    public TodoListViewModel(ITodoService todoService)
    {
        _todoService = todoService;
        TodoItems = new ObservableCollection<TodoItem>(_todoService.GetAllTodos());
        AddTodoCommand = new DelegateCommand(AddTodo);
        DeleteTodoCommand = new DelegateCommand<TodoItem>(DeleteTodo);
    }

    private void AddTodo()
    {
        if (!string.IsNullOrEmpty(NewTaskTitle))
        {
            var newItem = new TodoItem { Title = NewTaskTitle };
            _todoService.AddTodoItem(newItem);
            TodoItems.Add(newItem);
            NewTaskTitle = string.Empty;
        }
    }

    private void DeleteTodo(TodoItem item)
    {
        if (item is not null)
        {
            _todoService.RemoveTodoItem(item.Id);
            TodoItems.Remove(item);
        }
    }
}
