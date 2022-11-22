using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Entities
{
    public class User
    {

        private Guid id;
        private string username;
        private string password;
        private string name;
        private string type;
        private string address;
        private int age;
       

        public User(Guid id, string name, string username, string type)
        {
            this.id = id;
            this.name = name;
            this.username = username;
            this.type = type;
        }
        public User(Guid id, string name, string username,string password, string type)
        {
            this.id = id;
            this.name = name;
            this.username = username;
            this.type = type;
            this.password = password;
        }
        public User()
        {

        }

        public User(Guid id)
        {
            this.id = id;
        }

        public User(Guid id,  string username, string password, string type, string name, string address, int age) 
        {
            this.address = address;
            this.age = age;
            this.id = id;
            this.username = username;
            this.password = password;
            this.type = type;
            this.name = name;
        }

        public Guid GetId()
        {
            return id;
        }
        public void SetId(Guid id)
        {
            this.id = id;
        }
        public Guid Id { get { return GetId(); } set { SetId(value); } }

        public string GetName()
        {
            return name;
        }
        public void SetName(string name)
        {
            this.name = name;
        }
        public string Name { get { return GetName(); } set { SetName(value); } }


        public string GetUsername()
        {
            return username;
        }
        public void SetUsername(string username)
        {
            this.username = username;
        }
        public string Username { get { return GetUsername(); } set { SetUsername(value); } }

        public string GetPassword()
        {
            return password;
        }
        public void SetPassword(string password)
        {
            this.password = password;
        }
        public string Password { get { return GetPassword(); } set { SetPassword(value); } }

        public string GetType()
        {
            return type;
        }
        public void SetType(string type)
        {
            this.type = type;
        }
        public string Type { get { return GetType(); } set { SetType(value); } }

        public string GetAddress()
        {
            return address;
        }
        public void SetAddress(string address)
        {
            this.address=address;
        }
        public string Address { get { return GetAddress(); } set { SetAddress(value); } }

        public int GetAge()
        {
            return age;
        }
        public void SetAge(int age)
        {
            this.age = age;
        }
        public int Age { get { return GetAge(); } set { SetAge(value); } }

    }
}
