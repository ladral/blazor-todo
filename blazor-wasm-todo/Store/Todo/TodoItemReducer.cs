using System;
using Fluxor;

namespace blazor_wasm_todo.Store
{
    public static class TodoItemReducer
    {
        [ReducerMethod]
        public static TodoItemsState OnInitializeStore(TodoItemsState state, InitializeStore action)
        {
            return state with
            {
                IndexCounter = action.IndexCounter,
                TodoItems = action.TodoItems
            };
        }

        [ReducerMethod]
        public static TodoItemsState OnAddTodo(TodoItemsState state, AddTodo action)
        {
            
            action.todo.id = state.IndexCounter + 1;
            state.TodoItems.Add(action.todo);

            return state with
            {
                IndexCounter = state.IndexCounter + 1,
                TodoItems = state.TodoItems
            };
        }
        
        [ReducerMethod]
        public static TodoItemsState OnRemoveTodo(TodoItemsState state, RemoveTodo action)
        {
            state.TodoItems.RemoveAll(todo => todo.id == action.Id);

            return state with
            {
                IndexCounter = state.IndexCounter,
                TodoItems = state.TodoItems
            };
        }
        
    }
}