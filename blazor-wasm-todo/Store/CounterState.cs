using Fluxor;

namespace blazor_wasm_todo.Store
{
    public record CounterState
    {
        public int Count { get; init; }
    }

    public class CounterFeatureState : Feature<CounterState>
    {
        public override string GetName() => nameof(CounterState);

        protected override CounterState GetInitialState()
        {
            return new CounterState
            {
                Count = 0
            };
        }

    }
}