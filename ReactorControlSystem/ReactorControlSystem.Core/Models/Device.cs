using ReactorControlSystem.Core.Enums;

namespace ReactorControlSystem.Core.Models
{
    public class Device
    {
        public string Name { get; set; } = string.Empty;

        public string PortName { get; set; } = string.Empty;
        public int BaudRate { get; set; } = 9600;

        public string Ip { get; set; } = string.Empty;
        public int Port { get; set; }

        public DeviceConnectMode ConnectMode { get; set; }
        public DeviceStatus Status { get; set; } = DeviceStatus.Disconnected;
    }
}
