using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Entities
{
    public class Devices
    {
      

      public  Guid Id { get; set; }
      public  string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public int MaxHConsumption { get; set; }
        

        public Devices(Guid id,string name, string address, string description, int maxHConsumption)
        {
            this.Id = id;
            this.Name = name;
            this.MaxHConsumption = maxHConsumption;
            this.Description = description;
            this.Address = address;
        }

        public Devices(Guid id, string name, string address, int maxHConsumption) 
        {

            this.Id = id;
            this.Name = name;
            this.MaxHConsumption = maxHConsumption;
            this.Address = address;
        }
        public Devices()
        {

        }
    }
}
