using Ecommerce.DataBase;
using Ecommerce.DTO.User;
using Ecommerce.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ECommerceDbContext _context;
        private const int WorkFactor = 12;

        public UserController(ECommerceDbContext context)
        {
            _context = context;
        }

        [HttpPost("RegisterUser")]
        public async Task<ActionResult> RegisterUser(UserDto userInfo)
        {
            try
            {
                var userExisting = _context.Users.FirstOrDefault(user => user.Email == userInfo.Email);
                if (userExisting != null)
                    return Conflict("User already exists in the database!");

                if (userInfo.Password != userInfo.ConfirmPassword)
                    return StatusCode(400, "Passwords do not match!");

                UserEntity user = new()
                {
                    Name = userInfo.Name,
                    Email = userInfo.Email,
                    Password = BC.HashPassword(userInfo.Password, WorkFactor)
                };

                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                return StatusCode(201, "User successfully registered!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
