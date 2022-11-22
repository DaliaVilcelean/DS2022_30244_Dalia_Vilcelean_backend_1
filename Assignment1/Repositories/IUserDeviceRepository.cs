using Assignment1.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Assignment1.Repositories
{
    public interface IUserDeviceRepository:IBaseRepository<UserDevice>
    {
        Task<List<UserDevice>> FilterByUserId(Guid id);
    }
}
