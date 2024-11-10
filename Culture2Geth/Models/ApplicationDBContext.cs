using Microsoft.EntityFrameworkCore;
namespace Culture2Geth.Models

{
    public class ApplicationDBContext: DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) 
         : base (options)
        { 
        }
        public DbSet<User> User { get; set; }
        public DbSet<Interest> Interest { get; set; }
        public DbSet<UserInterest> UserInterest { get; set; }
    }
}
