using Assignment1.Database;
using Assignment1.Entities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Repositories
{
    public class DeviceRepository : IDeviceRepository
    {


        private DBConnectionWrapper connectionWrapper;
        public DeviceRepository(DBConnectionWrapper connectionWrapper)
        {
            this.connectionWrapper = connectionWrapper;
        }

        public async Task<Devices> Create(Devices t)
        {
            Devices device = null;
            if (t == null) Console.WriteLine("not found");
            using (MySqlConnection connection = connectionWrapper.InitializeConnection())
            {
                connection.Open();
                using (MySqlCommand command = connection.CreateCommand())
                {
                    t.Id = Guid.NewGuid();
                    command.CommandText = String.Format("INSERT into devices(id,name,description,address,maxHConsumption)" +
                        " VALUES('{0}','{1}','{2}','{3}','{4}'); ",
                        t.Id, t.Name,t.Description,t.Address,t.MaxHConsumption);
                    command.ExecuteNonQuery();

                    device = new Devices(t.Id, t.Name, t.Description, t.Address, t.MaxHConsumption);
                }
                connection.Close();
            }
            return device;
        }

        public async Task Delete(Devices t)
        {

            if (t == null) Console.WriteLine("not found");
            using (MySqlConnection connection = connectionWrapper.InitializeConnection())
            {
                connection.Open();
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = String.Format("DELETE from devices where id= '{0}';", t.Id);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        public async Task<List<Devices>> FindAll()
        {
            List<Devices> devices = new List<Devices>();

            using (MySqlConnection connection = connectionWrapper.InitializeConnection())
            {
                connection.Open();
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = String.Format("SELECT * from devices;");
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        devices.Add(new Devices(Guid.Parse(reader["id"].ToString()),
                            reader["name"].ToString(), reader["description"].ToString(),
                             reader["address"].ToString(),
                             Int32.Parse(reader["maxHConsumption"].ToString())));
                    }
                }
                connection.Close();
            }
            return devices;
        }

        public async Task<Devices> FindById(Guid id)
        {
            Devices devices = null;
            using (MySqlConnection connection = connectionWrapper.InitializeConnection())
            {
                connection.Open();
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = String.Format("SELECT * from devices where id='{0}';", id);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        devices = new Devices(Guid.Parse(reader["id"].ToString()), reader["name"].ToString(),
                            reader["description"].ToString(), reader["address"].ToString(),
                       Int32.Parse(reader["maxHConsumption"].ToString()));
                    }
                }
                connection.Close();
            }
            return devices;
        }

        public async Task<Devices> Update(Devices t)
        {
            Devices devices = null;
            if (t == null) Console.WriteLine("not found");
            using (MySqlConnection connection = connectionWrapper.InitializeConnection())
            {
                connection.Open();
                using (MySqlCommand command = connection.CreateCommand())
                {
                    
                    command.CommandText = String.Format("UPDATE devices SET name='{0}' , description='{1}', address='{2}'," +
                     "maxHConsumption='{3}'  WHERE id='{4}'; ",
                        t.Name,t.Description,t.Address,t.MaxHConsumption, t.Id);
                    command.ExecuteNonQuery();

                    devices = new Devices(t.Id,t.Name, t.Description, t.Address, t.MaxHConsumption);
                }
                connection.Close();
            }
            return devices;
        }
    }
}
