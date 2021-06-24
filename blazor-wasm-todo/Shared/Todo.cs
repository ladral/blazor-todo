namespace blazor_wasm_todo.Shared
{
    public class Todo
    {
        public int id { get; }
        public string title { get; }   
        public Todo(int id, string title)
        {
            this.id = id;
            this.title = title;
        }
    }
}