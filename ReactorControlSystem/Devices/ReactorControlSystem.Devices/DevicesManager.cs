using ReactorControlSystem.Repositories.Models;
using ReactorControlSystem.Devices.Reactor;

namespace ReactorControlSystem.Devices
{
    public class DevicesManager
    {
        private readonly Reactor1RTUService _reactor1;
        private readonly Reactor2RTUService _reactor2;

        public DevicesManager(Reactor1RTUService reactor1, Reactor2RTUService reactor2)
        {
            _reactor1 = reactor1;
            _reactor2 = reactor2;
        }

        public async Task<List<Device?>> InitializeAllAsync() 
        { 
            Task<bool> reactor1Result = _reactor1.ConnectAsync();
            Task<bool> reactor2Result = _reactor2.ConnectAsync();

            await Task.WhenAll(reactor1Result, reactor2Result);

            return new List<Device?>
            {
                _reactor1.Device,
                _reactor2.Device
            };
        }

        public void DisconnectAll()
        {
            _reactor1.Disconnect();
            _reactor2.Disconnect();
        }
    }
}
