using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PayaPocket.IRepositories;
using PayAPocket.DTOs.RequestDTO;
using System.Threading.Tasks;

namespace PayaPocket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        [Route("registerUser")]
        public async Task<ActionResult> AddAsync(UserRegistrationRequestDTO model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var response = await _userRepository.AddAsync(model);

            if (response.IsSuccessful == false)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
    
}
