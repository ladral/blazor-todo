using System.Collections.Generic;
using blazor_wasm_todo.Shared;

namespace blazor_wasm_todo.Store
{
    public record InitializeStore
    {
        public List<Todo> TodoItems { get; }    

        public InitializeStore(List<Todo> todoItems)
        {
            TodoItems = todoItems;
        }
    }
}