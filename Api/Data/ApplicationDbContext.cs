using Api.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Api.Data
{
    public class ApplicationDbContext:IdentityDbContext
    {
        public DbSet<AppUser> AppUsers { get; set; }
        public ApplicationDbContext (DbContextOptions options):base(options)
        {

        }
    }
}
