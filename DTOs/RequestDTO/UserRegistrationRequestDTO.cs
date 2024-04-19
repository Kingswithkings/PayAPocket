using System.ComponentModel.DataAnnotations;

namespace PayAPocket.DTOs.RequestDTO
{
    public class UserRegistrationRequestDTO
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
