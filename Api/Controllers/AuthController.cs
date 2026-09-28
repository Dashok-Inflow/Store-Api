using Api.Common;
using Api.Data;
using Api.ModelDto;
using Api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : StoreController
    {
        private readonly UserManager<AppUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public AuthController(ApplicationDbContext dbContext, UserManager<AppUser> userManager, 
            RoleManager<IdentityRole> roleManager) : base(dbContext)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        [HttpPost]
        public async Task<ActionResult<ResponseServer>> Register([FromBody] RegisterRequestDto registerRequestDto)
        {
            if (registerRequestDto == null)
            {
                return BadRequest(new ResponseServer
                {
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    ErrorMessages = { "Некорректная модель запроса" }
                });
            }

            var userFromDb = await dbContext.AppUsers.FirstOrDefaultAsync(x => 
            x.NormalizedUserName == registerRequestDto.UserName.ToUpper());

            if (userFromDb != null)
            {
                return BadRequest(new ResponseServer
                {
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    ErrorMessages = { "Такой пользователь уже существует" }
                });
            }

            var newAppUser = new AppUser
            {
                UserName = registerRequestDto.UserName,
                Email = registerRequestDto.Email,
                NormalizedEmail = registerRequestDto.Email,
                FirstName = registerRequestDto.UserName
            };

            var result = await userManager.CreateAsync(newAppUser, registerRequestDto.Password);

            if(!result.Succeeded)
            {
                return BadRequest(new ResponseServer
                {
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    ErrorMessages = { "Ошибка регистрации" }
                });
            }

            var newRoleAppUser = registerRequestDto.Role.Equals(SharedData.Roles.Admin, StringComparison.OrdinalIgnoreCase)
                ? SharedData.Roles.Admin : SharedData.Roles.Consumer;

            await userManager.AddToRoleAsync(newAppUser, newRoleAppUser);

            return Ok(new ResponseServer
            {
                StatusCode = HttpStatusCode.OK,
                Result = "Регитсрация завершена"
            });
        }
    }
}
