using System.IO.Ports;
using NModbus;
using NModbus.Serial;
using ReactorControlSystem.Core.Enums;
using ReactorControlSystem.Repositories.Models;

namespace ReactorControlSystem.Devices.Reactor
{
    public abstract class ReactorRTU : IReactor
    {
        private SerialPort? _serialPort;
        private IModbusMaster? _modbusMaster;
        private CancellationTokenSource? _cts;

        public Device? Device { get; set; }

        public abstract Task<Device?> GetDeviceAsync();
        public abstract Task<ushort> ReadTemperatureAsync();

        public async Task<bool> ConnectAsync()
        {
            Device = await GetDeviceAsync();
            if (Device == null)
            {
                return false;
            }

            Device.Status = DeviceStatus.Connecting;

            _serialPort ??= new SerialPort()
            {
                PortName = Device.PortName,
                BaudRate = Device.BaudRate,
                DataBits = 8,
                Parity = Parity.None,
                StopBits = StopBits.One,
            };

            try
            {
                _serialPort.Open();
            }
            catch (Exception ex)
            {
                Device.Status = DeviceStatus.Error;
                return false;
            }

            Device.Status = DeviceStatus.Connected;
            var factory = new ModbusFactory();
            _modbusMaster = factory.CreateRtuMaster(_serialPort);
            _cts = new CancellationTokenSource();
            return true;
        }

        public void Disconnect()
        {
            _cts?.Cancel();

            if (_serialPort != null && _serialPort.IsOpen)
            {
                _serialPort.Close();
            }
        }

    }
}
