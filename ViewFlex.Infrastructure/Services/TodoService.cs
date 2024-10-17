using ViewFlex.Core.Interfaces;
using ViewFlex.Core.Models;

namespace ViewFlex.Infrastructure.Services;

public class TodoService : ITodoService
{
    private int _nextTodoId = 6;
    private const string TitleName = "Test Todo";

    private readonly List<Todo> TodoList =
    [
        new() { Id = 1, Title = TitleName },
        new() { Id = 2, Title = TitleName },
        new() { Id = 3, Title = TitleName },
        new() { Id = 4, Title = TitleName },
        new() { Id = 5, Title = TitleName }
    ];

    public async Task<List<Todo>> GetTodoListAsync() => await Task.FromResult(TodoList);

    public async Task AddTodoAsync(Todo todo)
    {
        if (todo is not null)
        {
            todo.Id = _nextTodoId++;
            TodoList.Add(todo);
            await Task.CompletedTask;
        }
    }

    public async Task RemoveTodoAsync(int id)
    {
        var todo = TodoList.FirstOrDefault(x => x.Id == id);
        if (todo is not null) TodoList.Remove(todo);
        await Task.CompletedTask;
    }
}
