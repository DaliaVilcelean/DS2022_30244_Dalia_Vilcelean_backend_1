using Assignment1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.DTOs.Builders
{
    public class UserBuilder
    {

        public static UserDTO ToUserDTO(User user)
        {
            // return new UserDTO(user.Id, user.Name, user.Username, user.Type);
            return null;
        }

        

        public static User ToEntity(UserDTO user)
        {
            return new User(user.Id,user.Name,user.Username,user.Type);
        }
    }
}
