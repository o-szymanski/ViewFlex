using ViewFlex.Core.Interfaces;
using ViewFlex.Core.Models;

namespace ViewFlex.Infrastructure.Services;

public class TodoService : ITodoService
{
    private readonly List<TodoItem> _todoItems = [new TodoItem { Id = 1, IsCompleted = false, Title = "Go to the gym" }, new TodoItem { Id = 2, IsCompleted = false, Title = "Wash the dishes" }];
    public List<TodoItem> GetAllTodos() => _todoItems;
    public void AddTodoItem(TodoItem item) => _todoItems.Add(item);

    public void RemoveTodoItem(int id)
    {
        var item = _todoItems.FirstOrDefault(x => x.Id == id);
        if (item != null) _todoItems.Remove(item);
    }
}
