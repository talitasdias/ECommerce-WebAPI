﻿using Ecommerce.DataBase;
using Ecommerce.DTO;
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

                UserEntity user = new()
                {
                    Name = userInfo.Name,
                    Email = userInfo.Email,
                    Password = BC.HashPassword(userInfo.Password)
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
