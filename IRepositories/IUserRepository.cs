using System.Threading.Tasks;
using System;
using PayAPocket.DTOs.RequestDTO;
using PayAPocket.DTOs.ResponseDTO;
using PayAPocket.Generic;
using System.Collections.Generic;

namespace PayaPocket.IRepositories
{
    public interface IUserRepository
    {
        Task<Response<UserResponseDTO>> AddAsync(UserRegistrationRequestDTO model);
        Task<Response<UserResponseDTO>> GetByIdAsync(Guid UserId);
        Task<List<Response<UserResponseDTO>>> GetAllAsync();
        Task<Response<bool>> DeleteAsync(Guid UserId);
        Task<Response<bool>> UpdateAsync(Guid UserId, UpdateUserRequestDTO model);
    }
}
