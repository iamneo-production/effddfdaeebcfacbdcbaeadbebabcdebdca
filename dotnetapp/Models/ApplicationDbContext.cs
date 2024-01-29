using Microsoft.EntityFrameworkCore;

namespace dotnetapp.Models
{

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Dealer> Dealers { get; set; }

}
}