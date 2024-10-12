using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

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
        public User User { get; set; }


    }
}
