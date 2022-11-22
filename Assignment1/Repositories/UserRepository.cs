using Assignment1.Database;
using Assignment1.Entities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Repositories
{
    public class UserRepository:IUserRepository
    {

        private DBConnectionWrapper connectionWrapper;
        public UserRepository(DBConnectionWrapper connectionWrapper)
        {
            this.connectionWrapper = connectionWrapper;
        }

        public async Task<User> Create(User t)
        {
            User user = null;
            if (t == null) Console.WriteLine("not found");
            using(MySqlConnection connection = connectionWrapper.InitializeConnection())
            {
                connection.Open();
                using(MySqlCommand command = connection.CreateCommand())
                {
                    t.Id = Guid.NewGuid();
                    command.CommandText = String.Format("INSERT into users(id, username, password, type,nume, address, age)" +
                        " VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}'); ",
                         t.Id,t.Username,t.Password,t.Type,t.Name,t.Address,t.Age);
                    command.ExecuteNonQuery();
                   
                    user = new User(t.Id, t.Username, t.Password, t.Type, t.Name, t.Address,t.Age);
                }
                connection.Close();
            }
            return  user;
        }

        public async Task Delete(User t)
        {
          
            if (t == null) Console.WriteLine("not found");
            using (MySqlConnection connection =  connectionWrapper.InitializeConnection())
            {
                connection.Open();
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = String.Format("DELETE from users where id= '{0}';",t.Id);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        public async Task<List<User>> FindAll()
        {
            List<User> users = new List<User>();
           
            using (MySqlConnection connection = connectionWrapper.InitializeConnection())
            {
                connection.Open();
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = String.Format("SELECT * from users;");
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        users.Add(new User(Guid.Parse(reader["id"].ToString()), reader["username"].ToString(),
                            reader["password"].ToString(), reader["type"].ToString(),
                       reader["nume"].ToString(), reader["address"].ToString(), Int32.Parse(reader["age"].ToString())));
                    }
                }
                connection.Close();
            }
            return users;

        }

        public async Task<User> FindById(Guid id)
        {
            User user = null;
            using (MySqlConnection connection = connectionWrapper.InitializeConnection())
            {
                connection.Open();
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = String.Format("SELECT * from users where id='{0}';", id);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        user = new User(Guid.Parse(reader["id"].ToString()),reader["username"].ToString(), 
                            reader["password"].ToString(), reader["type"].ToString(),
                       reader["nume"].ToString(), reader["address"].ToString(), Int32.Parse(reader["age"].ToString()));
                    }
                }
                connection.Close();
            }
            return user;

        }

        public async Task<User> FindByUserNameAndPass(string username, string password)
        {
            User user = null;
            using (MySqlConnection connection = connectionWrapper.InitializeConnection())
            {
                connection.Open();
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = String.Format("SELECT * from users where username='{0}'" +
                        " and password='{1}';", username,password);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        user = new User(Guid.Parse(reader["id"].ToString()), reader["username"].ToString(),
                            reader["password"].ToString(), reader["type"].ToString(),
                       reader["nume"].ToString(), reader["address"].ToString(), Int32.Parse(reader["age"].ToString()));
                    }
                }
                connection.Close();
            }
            return user;
        }

        public async Task<User> Update(User t)
        {
            User user = null;
            if (t == null) Console.WriteLine("not found");
            using (MySqlConnection connection = connectionWrapper.InitializeConnection())
            {
                connection.Open();
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = String.Format("UPDATE users SET nume='{0}' , username='{1}', password='{2}'," +
                        "type='{3}', address='{4}', age='{5}'  WHERE id='{6}'; ",
                        t.Name,t.Username,t.Password,t.Type,t.Address,t.Age,t.Id);
                    command.ExecuteNonQuery();
                  
                    user = new User(t.Id, t.Username, t.Password, t.Type, t.Name, t.Address, t.Age);
                }
                connection.Close();
            }
            return user;
        }

   
    }
}
