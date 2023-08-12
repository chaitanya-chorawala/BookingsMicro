using Identity.API.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace Identity.API.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<User> User { get; set; }    
    public DbSet<UserRefreshToken> RefreshToken { get; set; }
}
