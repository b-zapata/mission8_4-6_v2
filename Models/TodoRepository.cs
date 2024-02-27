namespace mission8_4_6_v2.Models
{
    public class TodoRepository : ITodoRepository
    {
        public TodoContext _context { get; set; }
        public TodoRepository(TodoContext context) 
        {
            _context = context;
        }
        public List<Todo> Todos => _context.Todos.ToList();
        public void AddTodo(Todo Todo)
        {
            _context.Todos.Add(Todo);
            _context.SaveChanges();
        }
        public void UpdateTodo(Todo Todo)
        {
            _context.Todos.Update(Todo);
            _context.SaveChanges();
        }
        public void DeleteTodo(Todo Todo)
        {
            _context.Todos.Remove(Todo);
            _context.SaveChanges();
        }
        public Todo GetTodo(int TodoId)
        {
            Todo Todo = _context.Todos.Single(t => t.TodoId == TodoId);
            return Todo;
        }
    }
}
