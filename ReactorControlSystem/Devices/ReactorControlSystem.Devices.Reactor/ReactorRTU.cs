using System.IO.Ports;
using NModbus;
using NModbus.Serial;
using ReactorControlSystem.Core.Enums;
using ReactorControlSystem.Core.Models;

namespace ReactorControlSystem.Devices.Reactor
{
    public abstract class ReactorRTU : IReactor
    {
        private SerialPort? _serialPort;
        private IModbusMaster? _modbusMaster;

        public Device? Device { get; set; }

        public abstract Device? GetDevice();
        public abstract Task<ushort> ReadTemperatureAsync();

        public bool Connect()
        {
            Device = GetDevice();
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
                Thread.Sleep(1000);
            }
            catch (Exception ex)
            {
                Device.Status = DeviceStatus.Error;
                return false;
            }

            Device.Status = DeviceStatus.Connected;
            var factory = new ModbusFactory();
            _modbusMaster = factory.CreateRtuMaster(_serialPort);
            return true;
        }

        public void Disconnect()
        {
            if (_serialPort != null && _serialPort.IsOpen)
            {
                _serialPort.Close();
            }
        }

    }
}
