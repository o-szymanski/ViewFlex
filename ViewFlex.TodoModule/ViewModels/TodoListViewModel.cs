using System.Collections.ObjectModel;
using ViewFlex.Core.Interfaces;
using ViewFlex.Core.Models;

namespace ViewFlex.TodoModule.ViewModels;

public class TodoListViewModel : BindableBase
{
    public DelegateCommand AddTodoCommand { get; private set; }
    public DelegateCommand<Todo> DeleteTodoCommand { get; private set; }
    public ObservableCollection<Todo> TodoList { get; set; }

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
        TodoList = new ObservableCollection<Todo>(_todoService.GetTodoList());
        AddTodoCommand = new DelegateCommand(AddTodo);
        DeleteTodoCommand = new DelegateCommand<Todo>(DeleteTodo);
    }

    private void AddTodo()
    {
        if (!string.IsNullOrEmpty(NewTodoTitle))
        {
            var todo = new Todo { Title = NewTodoTitle };
            _todoService.AddTodo(todo);
            TodoList.Add(todo);
            NewTodoTitle = string.Empty;
        }
    }

    private void DeleteTodo(Todo todo)
    {
        if (todo is not null)
        {
            _todoService.RemoveTodo(todo.Id);
            TodoList.Remove(todo);
        }
    }
}
