using System.Collections.Generic;
using System.Threading.Tasks;
using blazor_wasm_todo.Shared;

namespace blazor_wasm_todo.Data
{
    public interface IDataStorage
    {
        public Task<List<Todo>> Load();

        public Task Persist(List<Todo> todoItems);

        public Task<Todo> saveTodo(Todo todo);
        
        public Task deleteTodo(int id);
    }
}