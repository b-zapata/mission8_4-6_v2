namespace mission8_4_6_v2.Models
{
    public class TaskRepository : ITaskRepository
    {
        public TaskContext _context { get; set; }
        public TaskRepository(TaskContext context) 
        {
            _context = context;
        }
        public List<Task> Tasks => _context.Tasks.ToList();
        public void AddTask(Task task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();
        }
        public void UpdateTask(Task task)
        {
            _context.Tasks.Update(task);
            _context.SaveChanges();
        }
        public void DeleteTask(Task task)
        {
            _context.Tasks.Remove(task);
            _context.SaveChanges();
        }
        public Task GetTask(int TaskId)
        {
            Task task = _context.Tasks.Single(t => t.TaskId == TaskId);
            return task;
        }
    }
}
