namespace blazor_wasm_todo.Store
{
    public class DeleteTodoAction
    {
        public int Id { get; }

        public DeleteTodoAction(int id)
        {
            this.Id = id;
        }

    }
}   