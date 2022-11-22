using Assignment1.DTOs;
using Assignment1.DTOs.Builders;
using Assignment1.Entities;
using Assignment1.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Service
{
    public class DeviceService 
    {

        private DeviceRepository deviceRepository;

        public DeviceService(DeviceRepository deviceRepository)
        {
            this.deviceRepository = deviceRepository;
        }

        public async Task<List<DeviceDTO>> FindAllDevices()
        {
            List<Devices> deviceList =await deviceRepository.FindAll();

            var newList = new List<DeviceDTO>();
            foreach (var device in deviceList)
            {
                newList.Add(DeviceBuilder.ToDeviceDTO(device));
            }
            return newList;
        }

        public  async Task<Devices> AddDevice(Devices devices)
        {
            var device = await deviceRepository.Create(devices);
            return device;
        }

        public async Task DeleteDevice(Devices d)
        {
           await deviceRepository.Delete(d);
        }
        public async Task<DeviceDTO> FindById(Guid id)
        {
            var devices=await deviceRepository.FindById(id);
            return DeviceBuilder.ToDeviceDTO(devices);
        }

        public  async Task<Devices> UpdateDevice(Devices d)
        {
            var device = await deviceRepository.Update(d);
            return device;
        }
    }
}
