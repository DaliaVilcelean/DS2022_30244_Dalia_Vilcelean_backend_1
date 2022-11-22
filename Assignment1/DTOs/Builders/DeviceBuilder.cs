using Assignment1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.DTOs.Builders
{
    public class DeviceBuilder
    {

        public static DeviceDTO ToDeviceDTO(Devices device)
        {
            return new DeviceDTO(device.Id, device.Name, device.Address, device.MaxHConsumption);
        }

        public static Devices ToEntity(DeviceDTO device)
        {
            return new Devices(device.Id, device.Name, device.Address, device.MaxHConsumption);
        }
    }
}
