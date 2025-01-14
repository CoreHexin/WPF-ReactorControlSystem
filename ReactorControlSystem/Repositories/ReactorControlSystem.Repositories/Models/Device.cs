using Microsoft.EntityFrameworkCore;
using ReactorControlSystem.Core.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReactorControlSystem.Repositories.Models
{
    [Index(nameof(Name), IsUnique = true)]
    public class Device
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        
        public string Name { get; set; } = string.Empty;

        [MaxLength(10)]
        public string PortName { get; set; } = string.Empty;
        public int BaudRate { get; set; }

        [MaxLength(16)]
        public string Ip { get; set; } = string.Empty;
        public int Port { get; set; }

        [Required]
        public DeviceConnectMode ConnectMode { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [NotMapped]
        public DeviceStatus Status { get; set; }
    }
}
