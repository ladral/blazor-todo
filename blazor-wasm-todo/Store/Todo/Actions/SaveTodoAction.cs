using blazor_wasm_todo.Shared;

namespace blazor_wasm_todo.Store
{
    public class SaveTodoAction
    {
        public Todo todo { get; }      

        public SaveTodoAction(Todo todo)
        {
            this.todo = todo;
        }
    }
}