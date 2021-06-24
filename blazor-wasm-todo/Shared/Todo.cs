namespace blazor_wasm_todo.Shared
{
    public class Todo
    {
        private int id { get; set;  }
        public string title { get; }   
        public Todo(int id, string title)
        {
            this.id = id;
            this.title = title;
        }
        public void setId(int id)
        {
            this.id = id;
        }
        
        public int getId()
        {
            return this.id;
        }
    }
}