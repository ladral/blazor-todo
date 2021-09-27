namespace blazor_wasm_todo.Store
{
    public class RemoveTodoAction
    {
        public int Id { get; }

        public RemoveTodoAction(int id)
        {
            this.Id = id;
        }
    }
}