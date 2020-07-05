using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ErrorCentralApi.Models
{
  public class ErrorCentralDataContext : DbContext
  {
    private readonly IConfiguration _configuration;
    public ErrorCentralDataContext(IConfiguration configuration)
    {
      _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlServer(_configuration.GetConnectionString("AzureErrorCentralDataBaseServer"));
    }
    // public ErrorCentralDataContext(DbContextOptions<ErrorCentralDataContext> options) : base(options)
    // {

    // }

    public DbSet<Error> Errors { get; set; }
    public DbSet<User> Users { get; set; }
  }
}