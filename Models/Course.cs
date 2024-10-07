using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Depi_Final_Project.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        [MaxLength(100)]
        [Required]
        public string CourseName { get; set; }

        public string Description { get; set; }

        public int NoOfVideos { get; set;}
        public int Price { get; set; }
        public int CategoryId {  get; set; }
        public Category Category { get; set; }
        public List<Video> Videos { get; set; }
    }
}
