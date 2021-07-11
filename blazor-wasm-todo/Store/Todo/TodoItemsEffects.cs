using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using blazor_wasm_todo.Shared;
using Blazored.LocalStorage;
using Fluxor;

namespace blazor_wasm_todo.Store
{
    public class TodoItemsEffects
    {
        
        private readonly ILocalStorageService LocalStorage;
        private const string TodoItemsStorageKey = "todoItems";
        private const string IndexCounterStorageKey = "indexCounter";
        
        public TodoItemsEffects(ILocalStorageService localStorage)
        {
            LocalStorage = localStorage;
        }
        
        [EffectMethod]
        public async Task OnLoad(LoadFromDB action, IDispatcher dispatcher)
        {
            var todoItems = await LocalStorage.GetItemAsync<List<Todo>>(TodoItemsStorageKey) ?? new();
            var indexCounter = await LocalStorage.GetItemAsync<int>(IndexCounterStorageKey);
            Console.WriteLine(indexCounter);
            dispatcher.Dispatch(new InitializeStore(todoItems, indexCounter));
        }

        [EffectMethod]
        public async Task OnPersist(PersistToDB action, IDispatcher dispatcher)
        {
            await LocalStorage.SetItemAsync(TodoItemsStorageKey, action.TodoItemsState.TodoItems);
            await LocalStorage.SetItemAsync(IndexCounterStorageKey, action.TodoItemsState.IndexCounter);
        }
    }
}