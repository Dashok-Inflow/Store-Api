using Api.Common;
using Api.Data;
using Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthTestController : StoreController
    {
        public AuthTestController(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        [HttpGet("Test1")]
        public IActionResult Test1()
        {
            return Ok(new ResponseServer
            {
                StatusCode = HttpStatusCode.OK,
                Result = "Test1: Для всех"
            });
        }

        [HttpGet("Test2")]
        [Authorize]
        public IActionResult Test2()
        {
            return Ok(new ResponseServer
            {
                StatusCode = HttpStatusCode.OK,
                Result = "Test2: Для авторизированных пользователей"
            });
        }

        [HttpGet("Test3")]
        [Authorize(Roles = SharedData.Roles.Consumer)]
        public IActionResult Test3()
        {
            return Ok(new ResponseServer
            {
                StatusCode = HttpStatusCode.OK,
                Result = "Test3: Для авторизированных пользователей с правами Consumer"
            });
        }

        [HttpGet("Test4")]
        [Authorize(Roles = SharedData.Roles.Admin)]
        public IActionResult Test4()
        {
            return Ok(new ResponseServer
            {
                StatusCode = HttpStatusCode.OK,
                Result = "Test4: Для авторизированных пользователей с правами Admin"
            });
        }
    }
}
