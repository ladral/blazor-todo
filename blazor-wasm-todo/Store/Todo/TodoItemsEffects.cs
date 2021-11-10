using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using blazor_wasm_todo.Data;
using blazor_wasm_todo.Shared;
using Blazored.LocalStorage;
using Fluxor;
using Microsoft.AspNetCore.Components;

namespace blazor_wasm_todo.Store
{
    public class TodoItemsEffects
    {
        private readonly ITodoService _storage;
        private List<Todo> todoItems;
        
        public TodoItemsEffects(ITodoService storage)
        {
            _storage = storage;
        }
        
        [EffectMethod]
        public async Task OnLoadFromStorage(LoadFromStorageAction action, IDispatcher dispatcher)
        {
            todoItems = await _storage.Load();
            dispatcher.Dispatch(new InitializeStoreAction(todoItems));
        }

        [EffectMethod]
        public async Task OnSaveTodo(SaveTodoAction action, IDispatcher dispatcher)
        {
            Todo todo = await _storage.SaveTodo(action.todo);
            dispatcher.Dispatch(new AddTodoAction(todo));
        }
        
        [EffectMethod]
        public async Task OnDeleteTodo(DeleteTodoAction action, IDispatcher dispatcher)
        {
            await _storage.DeleteTodo(action.Id);
            dispatcher.Dispatch(new RemoveTodoAction(action.Id));
        }
    }
}