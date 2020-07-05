using System;

namespace ErrorCentralApi.Models
{
  public enum Environment
  {
    Produção, Homologação, Desenvolvimento
  }

  public class Error
  {
    public Guid Id { get; set; }
    public string LevelType { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public bool ArchiveRecord { get; set; }
    public DateTime CreatedAt { get; set; }
    public Environment Environment { get; set; }

    public virtual User User { get; set; }
  }
}