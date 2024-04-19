using AutoMapper;
using PayaPocket.Models;
using PayAPocket.DTOs.ResponseDTO;

namespace PayaPocket.AutoMapperProfiles
{
    public class Profiles : Profile
    {
        public Profiles() 
        {
            CreateMap<User, UserResponseDTO>().ReverseMap();
        }
    }
}
