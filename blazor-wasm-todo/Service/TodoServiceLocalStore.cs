using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using blazor_wasm_todo.Shared;
using Blazored.LocalStorage;

namespace blazor_wasm_todo.Data
{
    public class TodoServiceLocalStore : ITodoService
    {
        private readonly ILocalStorageService _localStorage;
        private const string TodoItemsStorageKey = "todoItems";
        private int NextTodoItemId { get; set; }
        private List<Todo> TodoItems { get; set; }          

        public TodoServiceLocalStore(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }
        
        public async Task<List<Todo>> LoadAll()
        {
            TodoItems = await _localStorage.GetItemAsync<List<Todo>>(TodoItemsStorageKey) ?? new();
            NextTodoItemId = EvaluateNextTodoItemId(TodoItems);
            return TodoItems;
        }

        private async Task Persist(List<Todo> todoItems)
        {
            await _localStorage.SetItemAsync(TodoItemsStorageKey, todoItems);
        }

        public async Task<Todo> Save(Todo todo)
        {
            todo.Id = NextTodoItemId;
            TodoItems.Add(todo);
            await Persist(TodoItems);
            NextTodoItemId = EvaluateNextTodoItemId(TodoItems);
            return todo;
        }

        public async Task Delete(int id)
        {
            TodoItems.RemoveAll(todo => todo.Id == id);
            await Persist(TodoItems);
            NextTodoItemId = EvaluateNextTodoItemId(TodoItems);
        }

        private static int EvaluateNextTodoItemId(List<Todo> todoItems)
        {
            if (todoItems == null) throw new ArgumentNullException(nameof(todoItems));
            var highestId = todoItems
                .Select(todo => todo.Id)
                .DefaultIfEmpty(0)
                .Max();
            
            return ++highestId;
        }
    }
}