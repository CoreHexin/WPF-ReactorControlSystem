using ReactorControlSystem.Core.Models;

namespace ReactorControlSystem.Devices.Reactor
{
    public interface IReactor
    {
        Device? Device { get; set; }
        bool Connect();
        void Disconnect();

        Task<ushort> ReadTemperatureAsync();
    }
}
