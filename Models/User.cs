using System;

namespace PayaPocket.Models
{
    public class User
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public Guid UserWalletId { get; set; }//identifier for d user digital wallet 
        public DateTime DateOfBirth { get; set; }
        public string HouseAddress { get; set; }
        public DateTime CreationDate { get; set; }//date & time when the user account was created
    }
}
