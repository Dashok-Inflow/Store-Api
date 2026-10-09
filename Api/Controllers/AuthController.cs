using Api.Common;
using Api.Data;
using Api.ModelDto;
using Api.Models;
using Api.Service;
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
        private readonly JwtTokenGenerator jwtTokenGenerator;

        public AuthController(ApplicationDbContext dbContext, UserManager<AppUser> userManager, 
            RoleManager<IdentityRole> roleManager,
            JwtTokenGenerator jwtTokenGenerator) : base(dbContext)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.jwtTokenGenerator = jwtTokenGenerator;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto registerRequestDto)
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

        [HttpPost("Login")]
        public async Task<ActionResult<ResponseServer>> Login(
            [FromBody] LoginRequestDto loginRequestDto)
        {
            var userFromDb = await dbContext.AppUsers.FirstOrDefaultAsync(u =>
            u.Email.ToLower() == loginRequestDto.Email.ToLower());

            if (userFromDb == null ||
                !await userManager.CheckPasswordAsync(userFromDb, loginRequestDto.Password))
            {
                return BadRequest(new ResponseServer
                {
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    ErrorMessages = { "Такого пользователя нет" }
                });
            }

            var roles = await userManager.GetRolesAsync(userFromDb);
            var token = jwtTokenGenerator.GenerateJwtToken(userFromDb, roles);

            return Ok(new ResponseServer
            {
                StatusCode = HttpStatusCode.OK,
                Result = new LoginResponseDto
                {
                    Email = userFromDb.Email,
                    Token = token,
                }
            });
        }
    }
}
