using System.Collections.Generic;
using blazor_wasm_todo.Shared;

namespace blazor_wasm_todo.Store
{
    public class InitializeStore
    {
        public List<Todo> TodoItems { get; }      
        public int IndexCounter { get; }      

        public InitializeStore(List<Todo> todoItems, int indexCounter)
        {
            TodoItems = todoItems;
            IndexCounter = indexCounter;
        }
    }
}