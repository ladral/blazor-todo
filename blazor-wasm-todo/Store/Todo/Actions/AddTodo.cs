using blazor_wasm_todo.Shared;

namespace blazor_wasm_todo.Store
{
    public record AddTodo
    {
        public Todo todo { get; }      

        public AddTodo(Todo todo)
        {
            this.todo = todo;
        }
    }
}