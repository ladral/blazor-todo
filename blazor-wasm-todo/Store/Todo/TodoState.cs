using Fluxor;

namespace blazor_wasm_todo.Store
{
    public record TodoState
    {
        public int Count { get; init; }
    }

    public class TodoFeatureState : Feature<TodoState>
    {
        public override string GetName() => nameof(TodoState);

        protected override TodoState GetInitialState()
        {
            return new TodoState
            {
                Count = 0
            };
        }

    }
}