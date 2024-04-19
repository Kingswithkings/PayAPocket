using System;

namespace PayAPocket.DTOs.ResponseDTO
{
    public class UserResponseDTO
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string EmailAddress { get; set; }
        public Guid UserWalletId { get; set; }
    }
}
