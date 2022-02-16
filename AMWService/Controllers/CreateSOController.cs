using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AMWService.IdentityAuth;
using AMWService.Models;
using Microsoft.AspNetCore.Identity;

namespace AMWService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreateSOController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly CreateSO _configuration;

        public CreateSOController(UserManager<User> userManager, CreateSO configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("CreateSO")]
        public async Task<IActionResult> CreateSO([FromBody] Register model)
        {
            var userExists = await _userManager.FindByNameAsync(model.Username);  //เช็ค Username
            if (userExists != null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User Already Exists!" });
            }

            User user = new User()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Creation Failed!" });
            }
            return Ok(new Response { Status = "Success", Message = "Create Successfully!" });
        }
    }
}
