using System.ComponentModel.DataAnnotations;

namespace Depi_Final_Project.Models
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

