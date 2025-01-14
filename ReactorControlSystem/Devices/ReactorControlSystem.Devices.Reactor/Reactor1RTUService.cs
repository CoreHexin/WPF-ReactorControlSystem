using ReactorControlSystem.Repositories.Models;
using ReactorControlSystem.Repositories.Interfaces;

namespace ReactorControlSystem.Devices.Reactor
{
    public class Reactor1RTUService : ReactorRTU
    {
        private readonly IDeviceRepository _deviceRepository;

        public Reactor1RTUService(IDeviceRepository deviceRepository)
        {
            _deviceRepository = deviceRepository;
        }

        public override async Task<Device?> GetDeviceAsync()
        {
            return await _deviceRepository.GetAsync("1#反应釜");
        }

        public override Task<ushort> ReadTemperatureAsync()
        {
            throw new NotImplementedException();
        }
    }
}
