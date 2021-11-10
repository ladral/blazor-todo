using System.Collections.Generic;
using System.Threading.Tasks;
using blazor_wasm_todo.Shared;

namespace blazor_wasm_todo.Data
{
    public interface ITodoService
    {
        public Task<List<Todo>> LoadAll();

        public Task<Todo> Save(Todo todo);
        
        public Task Delete(int id);
    }
}