using Assignment1.Entities;
using Assignment1.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Service
{
    public class UserDeviceService
    {

        private UserDeviceRepository userDeviceRepository;

        public UserDeviceService(UserDeviceRepository userDeviceRepository)
        {
            this.userDeviceRepository = userDeviceRepository;
        }

        public async Task<UserDevice> AddUserDevice(UserDevice ud)
        {
            var userDevice =await userDeviceRepository.Create(ud);
            return userDevice;
        }
        public async Task<List<UserDevice>> FilterByUser(Guid id)
        {
            var userDevice = await userDeviceRepository.FilterByUserId(id);
            var newList = new List<UserDevice>();


            foreach (var user in userDevice)
            {
                newList.Add(new UserDevice
                {
                    idUser=user.idUser,
                    idDevice=user.idDevice,
                    Address=user.Address
                });
            }
            return newList;
        }

    }
}
