using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace mission8_4_6_v2.Models;

public partial class Todo
{
    [Key]
    [Required(ErrorMessage = "TodoId is a required field")]
    public int TodoId { get; set; }
    [Required(ErrorMessage = "Todo is a required field")]
    public string TodoName { get; set; } = string.Empty;
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
    public virtual Category? Category { get; set; }
    public bool? Completed { get; set; }
}
