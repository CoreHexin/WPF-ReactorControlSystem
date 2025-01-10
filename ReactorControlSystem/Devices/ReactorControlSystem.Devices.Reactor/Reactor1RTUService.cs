using ReactorControlSystem.Core.Models;

namespace ReactorControlSystem.Devices.Reactor
{
    public class Reactor1RTUService : ReactorRTU
    {
        public override Device? GetDevice()
        {
            // todo: 从数据库读取
            var device = new Device()
            {
                Name = "1#反应釜",
                PortName = "COM1"
            };
            return device;
        }

        public override Task<ushort> ReadTemperatureAsync()
        {
            throw new NotImplementedException();
        }
    }
}
