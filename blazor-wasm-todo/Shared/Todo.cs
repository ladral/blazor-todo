namespace blazor_wasm_todo.Shared
{
    public class Todo
    {
        public int Id { get; set; }
        public string Title { get; }
        public string Description { get; }
        public Todo(int id, string title, string description)
        {
            this.Id = id;
            this.Title = title;
            this.Description = description;
        }
    }
}