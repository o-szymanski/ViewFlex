using ViewFlex.Core.Interfaces;
using ViewFlex.Core.Models;

namespace ViewFlex.Infrastructure.Services;

public class TodoService : ITodoService
{
    private int _nextId = 6;
    private readonly List<TodoItem> _todoItems =
    [
        new() { Id = 1, Title = "Test Task" },
        new() { Id = 2, Title = "Test Task" },
        new() { Id = 3, Title = "Test Task" },
        new() { Id = 4, Title = "Test Task" },
        new() { Id = 5, Title = "Test Task" }
    ];

    public List<TodoItem> GetAllTodos() => _todoItems;

    public void AddTodoItem(TodoItem item)
    {
        if (item is not null)
        {
            item.Id = _nextId++;
            _todoItems.Add(item);
        }
    }

    public void RemoveTodoItem(int id)
    {
        var item = _todoItems.FirstOrDefault(x => x.Id == id);
        if (item is not null) _todoItems.Remove(item);
    }
}
