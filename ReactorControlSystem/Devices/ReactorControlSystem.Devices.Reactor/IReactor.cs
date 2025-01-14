using ReactorControlSystem.Repositories.Models;

namespace ReactorControlSystem.Devices.Reactor
{
    public interface IReactor
    {
        Device? Device { get; set; }
        Task<bool> ConnectAsync();
        void Disconnect();

        Task<ushort> ReadTemperatureAsync();
    }
}
