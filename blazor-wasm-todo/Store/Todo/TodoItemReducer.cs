using blazor_wasm_todo.Shared;
using Fluxor;

namespace blazor_wasm_todo.Store
{
    public static class TodoItemReducer
    {
        [ReducerMethod]
        public static TodoItemsState OnAddTodo(TodoItemsState state, AddTodo action)
        {
            
            action.todo.id = state.Count + 1;
            state.TodoItems.Add(action.todo);
            
            return state with
            {
                Count = state.Count + 1,
                TodoItems = state.TodoItems
            };
        }
    }
}