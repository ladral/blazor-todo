﻿using System.Collections.Generic;
using blazor_wasm_todo.Shared;
using Fluxor;

namespace blazor_wasm_todo.Store
{
    public record TodoItemsState
    { 
        public List<Todo> TodoItems { get; init; }
    }

    public class TodoFeatureState : Feature<TodoItemsState>
    {
        public override string GetName() => nameof(TodoItemsState);

        protected override TodoItemsState GetInitialState()
        {
            return new TodoItemsState
            {
                TodoItems = new List<Todo>()
            };
        }

    }
}