using System;
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
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder
        .Entity<Error>()
        .Property(e => e.Environment)
        .HasConversion(
            v => v.ToString(),
            v => (Environment)Enum.Parse(typeof(Environment), v)
        );
      
      modelBuilder
        .Entity<Error>()
        .Property(e => e.LevelType)
        .HasConversion(
          v => v.ToString(),
          v => (LevelType)Enum.Parse(typeof(LevelType), v)
        );

      modelBuilder
        .Entity<Error>()
        .Property(e => e.CreatedAt)
        .HasDefaultValueSql("CONVERT(datetime, GETDATE())");
    }

    public DbSet<Error> Errors { get; set; }
    public DbSet<User> Users { get; set; }
  }
}