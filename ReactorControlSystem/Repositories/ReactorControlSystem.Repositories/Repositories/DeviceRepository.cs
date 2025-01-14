using Microsoft.EntityFrameworkCore;
using ReactorControlSystem.Repositories.Data;
using ReactorControlSystem.Repositories.Interfaces;
using ReactorControlSystem.Repositories.Models;

namespace ReactorControlSystem.Repositories.Repositories
{
    public class DeviceRepository : IDeviceRepository
    {
        private readonly AppDbContext _dbContext;

        public DeviceRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Device> AddAsync(Device device)
        {
            await _dbContext.Devices.AddAsync(device);
            await _dbContext.SaveChangesAsync();
            return device;
        }

        public async Task<Device?> DeleteAsync(int id)
        {
            var exsitingDevice = await _dbContext.Devices.FindAsync(id);
            if (exsitingDevice == null)
            {
                return null;
            }

            _dbContext.Devices.Remove(exsitingDevice);
            await _dbContext.SaveChangesAsync();
            return exsitingDevice;
        }

        public async Task<List<Device>> GetAllAsync()
        {
            return await _dbContext.Devices.ToListAsync();
        }

        public async Task<Device?> GetAsync(int id)
        {
            return await _dbContext.Devices.FindAsync(id);
        }

        public async Task<Device?> GetAsync(string name)
        {
            return await _dbContext.Devices.FirstOrDefaultAsync(device => device.Name == name);
        }

        public async Task<Device?> UpdateAsync(Device device)
        {
            var existingDevice = await _dbContext.Devices.FindAsync(device.Id);
            if (existingDevice == null)
            {
                return null;
            }

            existingDevice.Name = device.Name;
            existingDevice.PortName = device.PortName;
            existingDevice.BaudRate = device.BaudRate;
            existingDevice.Ip = device.Ip;
            existingDevice.Port = device.Port;
            existingDevice.ConnectMode = device.ConnectMode;

            await _dbContext.SaveChangesAsync();
            return existingDevice;
        }
    }
}
