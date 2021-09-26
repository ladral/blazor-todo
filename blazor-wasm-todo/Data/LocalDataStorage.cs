using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using blazor_wasm_todo.Shared;
using Blazored.LocalStorage;

namespace blazor_wasm_todo.Data
{
    public class LocalDataStorage : IDataStorage
    {
        private readonly ILocalStorageService LocalStorage;
        private const string TodoItemsStorageKey = "todoItems";
        private const string IndexCounterStorageKey = "indexCounter";
        private int indexCounter { get; set; }

        private List<Todo> TodoItems { get; set; }          

        public LocalDataStorage(ILocalStorageService localStorage)
        {
            LocalStorage = localStorage;
        }
        
        public async Task<List<Todo>> Load()
        {
            TodoItems = await LocalStorage.GetItemAsync<List<Todo>>(TodoItemsStorageKey) ?? new();
            
            return TodoItems;
        }

        public async Task Persist(List<Todo> todoItems)
        {
            await LocalStorage.SetItemAsync(TodoItemsStorageKey, todoItems);
            await LocalStorage.SetItemAsync(IndexCounterStorageKey, IndexCounterStorageKey);
        }

        public async Task<Todo> saveTodo(Todo todo)
        {
            indexCounter++;
            todo.id = indexCounter;
            TodoItems.Add(todo);
            await Persist(TodoItems);
            return todo;
        }

        public async Task<int> deleteTodo(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}