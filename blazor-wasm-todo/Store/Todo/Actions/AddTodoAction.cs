using blazor_wasm_todo.Shared;

namespace blazor_wasm_todo.Store
{
    public class AddTodoAction
    {
        public Todo Todo { get; }      

        public AddTodoAction(Todo todo)
        {
            this.Todo = todo;
        }
    }
}