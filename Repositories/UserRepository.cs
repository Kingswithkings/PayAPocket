using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PayaPocket.IRepositories;
using PayaPocket.Models;
using PayAPocket.DTOs.RequestDTO;
using PayAPocket.DTOs.ResponseDTO;
using PayAPocket.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayaPocket.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IMapper _mapper;

        public UserRepository(AppDbContext context, UserManager<IdentityUser> userManager, IMapper mapper)
        {
            _context = context;
            _userManager = userManager;
            _mapper = mapper;
        }
        public async Task<Response<UserResponseDTO>> AddAsync(UserRegistrationRequestDTO model)
        {
            Response<UserResponseDTO> response = new();

            try
            {
                //check if user already exist
                var existingUser = await _userManager.FindByEmailAsync  (model.EmailAddress);

                if (existingUser != null)
                {
                    response.IsSuccessful = false;
                    response.Error = new ResponseError()
                    {
                        ErrorCode = 21,
                        ErrorMessage = "User already exist"
                    };

                    return response;
                }

                //check if user already exist in db
                var existingUserindb = await _context.User
                    .Where(x => x.EmailAddress == model.EmailAddress && x.UserName == model.UserName)
                .FirstOrDefaultAsync();

                //do a method here that won't save the user twice//
                if (existingUserindb != null)
                {
                    response.IsSuccessful = false;
                    response.Error = new ResponseError()
                    {
                        ErrorCode = 21,
                        ErrorMessage = "User already exist"
                    };

                    return response;
                }

                IdentityUser identityUser = new()
                {
                    Email = model.EmailAddress,
                    UserName = model.UserName
                };

                //var addUser = await _userManager.CreateAsync(identityUser, model.Password);

                //if (!addUser.Succeeded)
                //{
                //    response.IsSuccessful = false;
                //    response.Error = new ResponseError()
                //    {
                //        ErrorCode = 21,
                //        ErrorMessage = "User Registeration Failed"
                //    };

                //    return response;
                //}

                //add the User to d database
                User user = new()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    EmailAddress = model.EmailAddress,
                    UserName = model.UserName,
                    
                };

                var addDUser = await _context.User.AddAsync(user);

                int isSaved = await _context.SaveChangesAsync();

                if (isSaved < 1)
                {
                    await _userManager.DeleteAsync(identityUser);
                    response.IsSuccessful = false;
                    response.Error = new ResponseError()
                    {
                        ErrorCode = 21,
                        ErrorMessage = "User Registeration Failed"
                    };

                    return response;
                }

                var responseDto = _mapper.Map<UserResponseDTO>(addDUser.Entity);

                response.IsSuccessful = true;
                response.Data = responseDto;
                response.ResponseCode = "00";
                response.Description = "Successful";
                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                response.Error = new ResponseError()
                {
                    ErrorCode = 55,
                    ErrorMessage = "internal server error"
                };
                response.Description = "please try again later";
            }
            return response;
        }

        public Task<Response<bool>> DeleteAsync(Guid UserId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Response<UserResponseDTO>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Response<UserResponseDTO>> GetByIdAsync(Guid UserId)
        {
            throw new NotImplementedException();
        }

        public Task<Response<bool>> UpdateAsync(Guid UserId, UpdateUserRequestDTO model)
        {
            throw new NotImplementedException();
        }
    }

    }
