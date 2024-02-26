using System.ComponentModel.DataAnnotations;
namespace mission8_4_6_v2.Models
{
    public class Category
    {
        [Key]
        [Required(ErrorMessage = "CategoryId is a required field")]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "CategoryName is a required field")]
        public string CategoryName { get; set; } = string.Empty;
    }
}
