using System;
using System.ComponentModel.DataAnnotations;

namespace ErrorCentralApi.DTOs
{
    public class ErrorDTO
    {
        public Guid Id { get; set; }
        [Required]
        public string LevelType { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Environment { get; set; }
        [Required]
        public string Origin { get; set; }
        public bool ArchiveRecord { get; set; }
        public DateTime CreatedAt { get; set; }
        
    }
}