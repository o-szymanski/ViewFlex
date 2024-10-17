using ViewFlex.Core.Models;

namespace ViewFlex.Core.Interfaces;

public interface ITodoService
{
    List<TodoItem> GetAllTodos();
    void AddTodoItem(TodoItem item);
    void RemoveTodoItem(int id);
}
