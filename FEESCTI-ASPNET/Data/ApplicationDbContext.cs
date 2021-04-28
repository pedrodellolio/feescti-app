using FEESCTI_ASPNET.Models;
using Microsoft.EntityFrameworkCore;

namespace FEESCTI_ASPNET.Data
{
  public class ApplicationDbContext : DbContext
  {

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    public DbSet<Inscricao> Inscricao { get; set; }
    public DbSet<Account> Account { get; set; }


  }
}
