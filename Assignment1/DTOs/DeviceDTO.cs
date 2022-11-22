using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.DTOs
{
    public class DeviceDTO
    {
        

        public DeviceDTO(Guid id, string name, string address, int maxHConsumption)
        {
            this.Id = id;
            this.Name = name;
            this.Address = address;
            this.MaxHConsumption = maxHConsumption;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int MaxHConsumption { get; set; }

    }
}
