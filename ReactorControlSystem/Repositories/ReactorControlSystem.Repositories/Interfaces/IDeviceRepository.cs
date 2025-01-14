using ReactorControlSystem.Repositories.Models;

namespace ReactorControlSystem.Repositories.Interfaces
{
    public interface IDeviceRepository
    {
        Task<List<Device>> GetAllAsync();
        Task<Device?> GetAsync(int id);
        Task<Device?> GetAsync(string name);
        Task<Device> AddAsync(Device device);
        Task<Device?> DeleteAsync(int id);
        Task<Device?> UpdateAsync(Device device);
    }
}
