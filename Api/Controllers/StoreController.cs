using Api.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        protected readonly ApplicationDbContext dbContext;
        public StoreController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
