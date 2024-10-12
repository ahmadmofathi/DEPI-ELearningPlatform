using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace E_LearningPlatform.Models
{
    public class Request
    {
        [Key]
        public int RequestId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        [ForeignKey("Course")]
        public int CourseId { get; set; }

        public string Description { get; set; }
        public string RequestStatus { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
