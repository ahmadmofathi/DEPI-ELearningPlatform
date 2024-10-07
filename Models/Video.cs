using System.ComponentModel.DataAnnotations;

namespace Depi_Final_Project.Models
{
    public class Video
    {
        [Key]
        public int VideoId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }
        public string Description { get; set; }
        public string VideoURL {  get; set; }
        public string Thumbnail {  get; set; }
        public TimeOnly VideoTime { get; set; }

        public DateTime? PublishDate { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }

    }
}
