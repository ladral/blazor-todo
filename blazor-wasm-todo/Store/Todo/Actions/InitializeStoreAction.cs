using System.Collections.Generic;
using blazor_wasm_todo.Shared;

namespace blazor_wasm_todo.Store
{
    public record InitializeStoreAction
    {
        public List<Todo> TodoItems { get; }    

        public InitializeStoreAction(List<Todo> todoItems)
        {
            TodoItems = todoItems;
        }
    }
}