using ViewFlex.Core.Models;

namespace ViewFlex.Core.Interfaces;

public interface ITodoService
{
    List<Todo> GetTodoList();
    void AddTodo(Todo todo);
    void RemoveTodo(int id);
}
