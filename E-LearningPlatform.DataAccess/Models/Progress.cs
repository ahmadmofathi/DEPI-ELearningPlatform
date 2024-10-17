using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_LearningPlatform.Models
{
    public class Progress
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Enrollment")]
        public int EnrollmentId { get; set; }

        [ForeignKey("Video")]
        public int VideoId { get; set; }
        public Enrollment Enrollment { get; set; }  // Navigation Property
        public Video Video { get; set; }  
    }
}
