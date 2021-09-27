using System;
using System.Collections.Generic;
using blazor_wasm_todo.Shared;
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
                TodoItems =  new List<Todo>(action.TodoItems)
            };
        }

        [ReducerMethod]
        public static TodoItemsState OnAddTodo(TodoItemsState state, AddTodoAction action)
        {
            state.TodoItems.Add(action.todo);
            return state with
            {
                TodoItems = new List<Todo>(state.TodoItems)
            };
        }
        
        [ReducerMethod]
        public static TodoItemsState OnRemoveTodo(TodoItemsState state, RemoveTodoAction action)
        {
            state.TodoItems.RemoveAll(todo => todo.id == action.Id);
            return state with
            {
                TodoItems = new List<Todo>(state.TodoItems)
            };
        }
        
    }
}