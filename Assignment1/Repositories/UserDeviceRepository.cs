using Assignment1.Database;
using Assignment1.Entities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Repositories
{
    public class UserDeviceRepository : IUserDeviceRepository
    {

        private DBConnectionWrapper connectionWrapper;
        public UserDeviceRepository(DBConnectionWrapper connectionWrapper)
        {
            this.connectionWrapper = connectionWrapper;
        }

        public async Task<UserDevice> Create(UserDevice t)
        {
            UserDevice userDevice = null;
            if (t == null) Console.WriteLine("not found");
            using (MySqlConnection connection = connectionWrapper.InitializeConnection())
            {
                connection.Open();
                using (MySqlCommand command = connection.CreateCommand())
                {

                    command.CommandText = String.Format("INSERT into userDevices(idUser,idDevice,address)" +
                        " VALUES('{0}','{1}','{2}'); ",
                       t.idUser,t.idDevice,t.Address);
                    command.ExecuteNonQuery();

                    userDevice = new UserDevice(t.idUser, t.idDevice, t.Address);
                }
                connection.Close();
            }
            return userDevice;
        }

        public async Task Delete(UserDevice t)
        {
            throw new NotImplementedException();
        }

        public async Task<List<UserDevice>> FindAll()
        {
            throw new NotImplementedException();
        }

        public async Task<List<UserDevice>> FilterByUserId(Guid id)
        {
            List<UserDevice> userDevice = new List<UserDevice>();
            using (MySqlConnection connection = connectionWrapper.InitializeConnection())
            {
                connection.Open();
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = String.Format("SELECT * from userDevices where idUser='{0}';" 
                       , id);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        userDevice.Add(new UserDevice(Guid.Parse(reader["idUser"].ToString()), Guid.Parse(reader["idDevice"].ToString()),
                            reader["address"].ToString()));
                    }
                }
                connection.Close();
            }
            return userDevice;
        }

        public async Task<UserDevice> Update(UserDevice t)
        {
            throw new NotImplementedException();
        }

        public Task<UserDevice> FindById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
