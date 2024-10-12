namespace E_LearningPlatform.Models
{
    public class Instructor
    {

        public int InstructorId { get; set; }
        public string? SocialMediaLink { get; set; }
        public string? Qualifications { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
