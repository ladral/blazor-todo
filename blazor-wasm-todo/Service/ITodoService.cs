using System.Collections.Generic;
using System.Threading.Tasks;
using blazor_wasm_todo.Shared;

namespace blazor_wasm_todo.Data
{
    public interface ITodoService
    {
        public Task<List<Todo>> Load();

        public Task<Todo> SaveTodo(Todo todo);
        
        public Task DeleteTodo(int id);
    }
}