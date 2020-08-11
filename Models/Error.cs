using System;

namespace ErrorCentralApi.Models
{
  public enum Environment
  {
    production, homologation, development
  }
  public enum LevelType
  {
    error, warning, debug, info
  }

  public class Error
  {
    public Guid Id { get; set; }
    public LevelType LevelType { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public bool ArchiveRecord { get; set; }
    public DateTime CreatedAt { get; set; }
    public Environment Environment { get; set; }
    public string Origin { get; set; }
    
    public virtual User User { get; set; }
  }
}