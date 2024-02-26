using System.ComponentModel.DataAnnotations;

namespace mission8_4_6_v2.Models
{
    public interface ITaskRepository
    {
        List<Task> Tasks { get; }
        public void AddTask(Task task);
        public void UpdateTask(Task task);
        public void DeleteTask(Task task);
        public Task GetTask(int TaskId);
    }
}
