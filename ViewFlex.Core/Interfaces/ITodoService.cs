using ViewFlex.Core.Models;

namespace ViewFlex.Core.Interfaces;

public interface ITodoService
{
    Task<List<Todo>> GetTodoListAsync();
    Task AddTodoAsync(Todo todo);
    Task RemoveTodoAsync(int id);
}
