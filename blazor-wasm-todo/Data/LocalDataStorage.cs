using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using blazor_wasm_todo.Shared;
using Blazored.LocalStorage;

namespace blazor_wasm_todo.Data
{
    public class LocalDataStorage : IDataStorage
    {
        private readonly ILocalStorageService _localStorage;
        private const string TodoItemsStorageKey = "todoItems";
        private int NextTodoItemId { get; set; }
        private List<Todo> TodoItems { get; set; }          

        public LocalDataStorage(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }
        
        public async Task<List<Todo>> Load()
        {
            TodoItems = await _localStorage.GetItemAsync<List<Todo>>(TodoItemsStorageKey) ?? new();
            NextTodoItemId = EvaluateNextTodoItemId(TodoItems);
            return TodoItems;
        }

        public async Task Persist(List<Todo> todoItems)
        {
            await _localStorage.SetItemAsync(TodoItemsStorageKey, todoItems);
        }

        public async Task<Todo> saveTodo(Todo todo)
        {
            todo.id = NextTodoItemId;
            TodoItems.Add(todo);
            await Persist(TodoItems);
            NextTodoItemId = EvaluateNextTodoItemId(TodoItems);
            return todo;
        }

        public async Task deleteTodo(int id)
        {
            TodoItems.RemoveAll(todo => todo.id == id);
            await Persist(TodoItems);
            NextTodoItemId = EvaluateNextTodoItemId(TodoItems);
        }

        private static int EvaluateNextTodoItemId(List<Todo> todoItems)
        {
            if (todoItems == null) throw new ArgumentNullException(nameof(todoItems));
            var highestId = todoItems
                .Select(todo => todo.id)
                .DefaultIfEmpty(0)
                .Max();
            
            return ++highestId;
        }
    }
}