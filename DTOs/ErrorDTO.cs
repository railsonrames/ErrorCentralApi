using System;

namespace ErrorCentralApi.DTOs
{
    public class ErrorDTO
    {
        public Guid Id { get; set; }
        public string LevelType { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool ArchiveRecord { get; set; }
        public DateTime CreatedAt { get; set; }
        // public Environment Environment { get; set; }
        
    }
}