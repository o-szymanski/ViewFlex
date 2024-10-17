using ViewFlex.Core.Interfaces;
using ViewFlex.Core.Models;

namespace ViewFlex.Infrastructure.Services;

public class TodoService : ITodoService
{
    private int _nextId = 6;

    private readonly List<Todo> TodoList =
    [
        new() { Id = 1, Title = "Test Todo" },
        new() { Id = 2, Title = "Test Todo" },
        new() { Id = 3, Title = "Test Todo" },
        new() { Id = 4, Title = "Test Todo" },
        new() { Id = 5, Title = "Test Todo" }
    ];

    public List<Todo> GetTodoList() => TodoList;

    public void AddTodo(Todo todo)
    {
        if (todo is not null)
        {
            todo.Id = _nextId++;
            TodoList.Add(todo);
        }
    }

    public void RemoveTodo(int id)
    {
        var todo = TodoList.FirstOrDefault(x => x.Id == id);
        if (todo is not null) TodoList.Remove(todo);
    }
}
