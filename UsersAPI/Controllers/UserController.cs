using MapsterMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using UsersAPI.Model.Contracts;
using UsersAPI.Model.Data;
using UsersAPI.Model.Dtos;

namespace UsersAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ILogger<UserController> _logger;
        private readonly IJWTManagerRepository _jWtManager;
        private readonly IUserRepository _userRepository;

        public UserController(IMapper mapper, ILogger<UserController> logger, IJWTManagerRepository jWtManager, IUserRepository userRepository)
        {
            _mapper = mapper;
            _logger = logger;
            _jWtManager = jWtManager;
            _userRepository = userRepository;
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginInput loginInput)
        {
            try
            {
                var userFound = await _userRepository.GetSingle(s => s.Login == loginInput.Login && s.Password == loginInput.Password);

                if (userFound == null)
                    return Unauthorized();

                var token = _jWtManager.Authenticate(userFound);
                return Ok(new
                {
                    Token = token,
                    UserInfo = _mapper.Map<LoginDto>(userFound)
                });
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return Problem();
            }
        }
        [Authorize]
        [HttpPut]
        public async Task<IActionResult> UpdateBalance(UpdateBalanceInput balanceInput)
        {
            if (!decimal.TryParse(balanceInput.Balance, out decimal balance))
                return BadRequest("Please provide a valid decimal value for balance");
            string login = (HttpContext.User.Identity as ClaimsIdentity).FindFirst(ClaimTypes.Name).Value;
            try
            {
                var user = await _userRepository.GetSingle(s => s.Login == login);
                user.UsdBalance = balance;
                await _userRepository.Update(user);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return Problem();
            }
            return Ok("Balance updated");
        }
        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> DeleteUser(DeleteUserInput deleteUserInput)
        {
            string role = (HttpContext.User.Identity as ClaimsIdentity).FindFirst(ClaimTypes.Role).Value;
            if (role != "admin")
                return BadRequest("You are not authorized to delete a user");
            try
            {
                var user = await _userRepository.GetSingle(s => s.Login == deleteUserInput.Login);
                if (user == null)
                    return BadRequest("The user to delete does not exist");
                string login = (HttpContext.User.Identity as ClaimsIdentity).FindFirst(ClaimTypes.Name).Value;
                if (login == deleteUserInput.Login)
                    return BadRequest("You cannot delete your own user");
                await _userRepository.Remove(user);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return Problem();
            }
            return Ok("User deleted");
        }
    }
}
