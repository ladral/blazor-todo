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
        private readonly IDataStorage _storage;
        private List<Todo> todoItems;
        
        public TodoItemsEffects(ILocalStorageService localStorage, IDataStorage storage)
        {
            _storage = storage;
        }
        
        [EffectMethod]
        public async Task OnLoadFromStorage(LoadFromStorage action, IDispatcher dispatcher)
        {
            todoItems = await _storage.Load();
            dispatcher.Dispatch(new InitializeStore(todoItems));
        }

        [EffectMethod]
        public async Task OnSaveTodo(SaveTodoAction action, IDispatcher dispatcher)
        {
            Todo todo = await _storage.saveTodo(action.todo);
            dispatcher.Dispatch(new AddTodoAction(todo));
        }
        
        [EffectMethod]
        public async Task OnDeleteTodo(DeleteTodoAction action, IDispatcher dispatcher)
        {
            await _storage.deleteTodo(action.Id);
            dispatcher.Dispatch(new RemoveTodoAction(action.Id));
        }
    }
}