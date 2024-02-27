using Microsoft.EntityFrameworkCore;
namespace mission8_4_6_v2.Models
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options) : base(options) { }
        public DbSet<Todo> Todos { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
