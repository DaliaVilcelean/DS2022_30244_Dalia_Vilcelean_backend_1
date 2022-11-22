using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Entities
{
    public class UserDevice
    {
  

        public Guid idUser { get; set; }
        public Guid idDevice { get; set; }
        public string Address {get;set;}

        public UserDevice()
        {

        }
        public UserDevice(Guid idUser, Guid idDevice, string address)
        {
            this.idUser = idUser;
            this.idDevice= idDevice;
            Address = address;
        }

    }
}
