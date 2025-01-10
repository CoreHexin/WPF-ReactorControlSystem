using System.Net.Sockets;
using NModbus;
using ReactorControlSystem.Core.Enums;
using ReactorControlSystem.Core.Models;

namespace ReactorControlSystem.Devices.Reactor
{
    public abstract class ReactorTCP : IReactor
    {
        private TcpClient? _tcpClient;
        private IModbusMaster? _modbusMaster;

        public Device? Device { get; set; }

        public abstract Device? GetDevice();

        public bool Connect()
        {
            Device = GetDevice();
            if (Device == null)
            {
                return false;
            }

            Device.Status = DeviceStatus.Connecting;

            _tcpClient ??= new TcpClient();

            try
            {
                _tcpClient.ConnectAsync(Device.Ip, Device.Port).Wait(3000);
            }
            catch (Exception ex)
            {
                Device.Status = DeviceStatus.Error;
                return false;
            }

            if (!_tcpClient.Connected)
            {
                Device.Status = DeviceStatus.Error;
                return false;
            }

            Device.Status = DeviceStatus.Connected;
            var factory = new ModbusFactory();
            _modbusMaster = factory.CreateMaster(_tcpClient);
            return true;
        }

        public void Disconnect()
        {
            if (_tcpClient != null && _tcpClient.Connected)
            {
                _tcpClient.Close();
            }
        }

        public Task<ushort> ReadTemperatureAsync()
        {
            throw new NotImplementedException();
        }
    }
}
