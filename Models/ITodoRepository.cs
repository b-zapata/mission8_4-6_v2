using System.ComponentModel.DataAnnotations;

namespace mission8_4_6_v2.Models
{
    public interface ITodoRepository
    {
        List<Todo> Todos { get; }
        public void AddTodo(Todo todo);
        public void UpdateTodo(Todo todo);
        public void DeleteTodo(Todo todo);
        public Todo GetTodo(int TodoId);
    }
}
