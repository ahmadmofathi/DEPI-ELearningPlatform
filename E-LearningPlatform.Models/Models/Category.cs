using System.ComponentModel.DataAnnotations;

namespace E_LearningPlatform.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        [MaxLength(20)]
        public string CategoryName { get; set; }
        public List<Course> Courses { get; set; }
    }
}
