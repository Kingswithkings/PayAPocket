using System;

namespace PayAPocket.DTOs.RequestDTO
{
    public class UpdateUserRequestDTO
    {
        public string PhoneNumber { get; set; } 
        public DateTime DateOfBirth { get; set; }
        public string HouseAddress { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
