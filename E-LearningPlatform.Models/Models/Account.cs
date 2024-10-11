using Microsoft.AspNetCore.Identity;

namespace E_LearningPlatform.Models
{
    public class Account : IdentityUser
    {
        public int AccountId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
