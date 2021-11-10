using System.Collections.Generic;
using blazor_wasm_todo.Shared;
using Fluxor;

namespace blazor_wasm_todo.Store
{
    [FeatureState]
    public record TodoItemsState
    {
        public List<Todo> TodoItems { get; init; }
    }
}