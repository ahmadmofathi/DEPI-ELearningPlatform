namespace E_LearningPlatform.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string? ProfilePicURL { get; set; }
        public string Bio { get; set; }
        public DateOnly Birthday { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }
    }
}
