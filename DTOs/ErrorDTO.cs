using System;

namespace ErrorCentralApi.DTOs
{
    public class ErrorDTO
    {
        public Guid Id { get; set; }
        public string LevelType { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Environment { get; set; }
        public string Origin { get; set; }
        public bool ArchiveRecord { get; set; }
        public DateTime CreatedAt { get; set; }
        
    }
}