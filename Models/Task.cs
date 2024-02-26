using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
namespace mission8_4_6_v2.Models
{
    public class Task
    {
        [Key]
        [Required(ErrorMessage = "TaskId is a required field")]
        public int TaskId { get; set; }
        [Required(ErrorMessage = "Task is a required field")]
        public string TaskName { get; set; } = string.Empty;
        [Range(1, 31, ErrorMessage = "Day must be between 1-31")]
        public int? Day { get; set; }
        [Range(1, 12, ErrorMessage = "Month must be between 1-12")]
        public int? Month { get; set; }
        [Range(2024, int.MinValue, ErrorMessage = "Year must be greater than 2024")]
        public int? Year { get; set; }
        [Required(ErrorMessage = "Urgent is a required field")]
        public bool Urgent { get; set; }
        [Required(ErrorMessage = "Important is a required field")]
        public bool Important { get; set; }
        [ForeignKey("Category")]
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
        public bool? Completed { get; set; }
    }
}
