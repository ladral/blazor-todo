using System.Collections.Generic;
using blazor_wasm_todo.Shared;

namespace blazor_wasm_todo.Store
{
    public class PersistToDB
    {
        public TodoItemsState TodoItemsState { get; }      

        public PersistToDB(TodoItemsState todoItemsState)
        {
            this.TodoItemsState = todoItemsState;
        }
    }
}