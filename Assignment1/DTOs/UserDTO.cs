using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.DTOs
{
    public class UserDTO
    {

      private  Guid id;
        private string name;
        private string username;
        private string type;

      

        public string GetUsername()
        {
            return username;
        }
        public void SetUsername(string username)
        {
            this.username = username;
        }
        public string Username { get { return GetUsername(); } set { SetUsername(value); } }
        public string GetName()
        {
            return name;
        }
        public void SetName(string name)
        {
            this.name = name;
        }
        public string Name { get { return GetName(); } set { SetName(value); } }
        public Guid GetId()
        {
            return id;
        }
        public void SetId(Guid id)
        {
            this.id = id;
        }
        public Guid Id { get { return GetId(); } set { SetId(value); } }
        public string GetType()
        {
            return type;
        }
        public void SetType(string type)
        {
            this.type = type;
        }
        public string Type { get { return GetType(); } set { SetType(value); } }

    }
    public class LogInDTO
    {
        public string   Username { get; set; }
        public string Password { get; set; }
    }

    public class LoginResponseDTO
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Type { get; set; }
    }
}
