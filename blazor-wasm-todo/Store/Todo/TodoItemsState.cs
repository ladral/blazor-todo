using System.Collections.Generic;
using blazor_wasm_todo.Shared;
using Fluxor;

namespace blazor_wasm_todo.Store
{
    public record TodoItemsState
    {
        public int IndexCounter { get; init; }
        public List<Todo> TodoItems { get; init; }
    }

    public class TodoFeatureState : Feature<TodoItemsState>
    {
        public override string GetName() => nameof(TodoItemsState);

        protected override TodoItemsState GetInitialState()
        {
            return new TodoItemsState
            {
                IndexCounter = 0,
                TodoItems = new List<Todo>()
            };
        }

    }
}