using ReactorControlSystem.Repositories.Interfaces;
using ReactorControlSystem.Repositories.Models;

namespace ReactorControlSystem.Devices.Reactor
{
    public class Reactor2RTUService : ReactorRTU
    {
        private readonly IDeviceRepository _deviceRepository;

        public Reactor2RTUService(IDeviceRepository deviceRepository)
        {
            _deviceRepository = deviceRepository;
        }

        public override async Task<Device?> GetDeviceAsync()
        {
            return await _deviceRepository.GetAsync("2#反应釜");
        }

        public override Task<ushort> ReadTemperatureAsync()
        {
            throw new NotImplementedException();
        }
    }
}
