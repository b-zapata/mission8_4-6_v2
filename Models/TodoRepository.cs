using Microsoft.EntityFrameworkCore;

namespace mission8_4_6_v2.Models
{
    public class TodoRepository : ITodoRepository
    {
        private TodosContext _context { get; set; }

        public TodoRepository(TodosContext context) 
        {
            _context = context;
        }
        // public List<Todo> Todos => _context.Todos.ToList();
        public List<Todo> Todos => _context.Todos.Include(t => t.Category).ToList();
        public List<Category> Categories => _context.Categories.ToList();
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
