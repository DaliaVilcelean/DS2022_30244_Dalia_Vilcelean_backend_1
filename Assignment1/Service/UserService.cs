using Assignment1.DTOs;
using Assignment1.DTOs.Builders;
using Assignment1.Entities;
using Assignment1.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Assignment1.Service
{
    public class UserService
    {

        private UserRepository userRepository;
  

        public UserService(UserRepository userRepository)
        {
            this.userRepository = userRepository;
            
        }

        public async Task<List<UserDTO>> FindAllUsers()
        {
            List<User> userList = await userRepository.FindAll();

            var newList = new List<UserDTO>();
            foreach(var user in userList)
            {
                newList.Add(new UserDTO
                {
                    Id=user.Id,
                    Name=user.Name,
                    Username=user.Username,
                    Type=user.Type
                }) ;
            }
            return newList;
        }

        public async Task<UserDTO> FindById(Guid id)
        {
            var user =await  userRepository.FindById(id);
            var userTO = new UserDTO
            {
                Id = user.Id,
                Name = user.Name,
                Username = user.Username,
                Type = user.Type

            };
            return userTO;
        }

        public async Task<User> AddUser(User u)
        {
            var user = await userRepository.Create(u);
            return user;
        }
        public async Task DeleteUser(User u)
        {
           await userRepository.Delete(u);
        }
        public async Task<User> UpdateUser(User u)
        {
            var user = await userRepository.Update(u);
            return user;
        }

        public async Task<LoginResponseDTO> SignInAsync(string email, string password)
        {
            var existingUser = await userRepository.FindByUserNameAndPass(email, password);
  
                    var user2= new LoginResponseDTO
                    {
                        Username = existingUser.Username,
                        Id = existingUser.Id,
                        Type=existingUser.Type

                    };
            return
                 user2;

           
        }
        public async Task SignOutAsync()
        {
            
        }

    }
}
