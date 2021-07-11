namespace blazor_wasm_todo.Store
{
    public class RemoveTodo
    {
        public int Id { get; }

        public RemoveTodo(int id)
        {
            Id = id;
        }
    }
}