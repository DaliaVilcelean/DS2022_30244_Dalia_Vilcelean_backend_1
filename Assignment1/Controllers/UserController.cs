using Assignment1.DTOs;
using Assignment1.DTOs.Builders;
using Assignment1.Entities;
using Assignment1.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private UserService userService;

        public UserController(UserService userService)
        {
            this.userService = userService;
        }


        [HttpPost]
        [Route("Login")]
       
        public async Task<IActionResult> Login([FromBody] LogInDTO logIn  )
        {
            var logIn1 =await userService.SignInAsync(logIn.Username, logIn.Password);
            return Ok(logIn1);
        }


        [HttpGet]
        [Route("FindAllUsers")]
        public async Task<ActionResult<UserDTO>> FindAllUsers()
        {
            
          var users =await userService.FindAllUsers();
            return Ok(users.ToList());
         }

        [HttpGet]
        [Route("FindUserById/{id}")]
        public async Task<ActionResult<User>> FindUserById([FromRoute] Guid id)
        {
            var user =await userService.FindById(id);
            return Ok(user);
        }

        [HttpPost]
        [Route("AddUser")]
      
        public async Task<ActionResult> AddUser([FromBody] User u)
        {
            var user = await userService.AddUser(u);
            return Ok(user);
        }

        [HttpPost]
        [Route("UpdateUser")]

        public async Task<ActionResult<UserDTO>> UpdateUser([FromBody] User u)
        {
            var user =await userService.UpdateUser(u);
            return Ok(user);
        }

        [HttpDelete]
        [Route("DeleteUser/{id}")]
        public async Task<ActionResult<UserDTO>> DeleteUserById([FromRoute] Guid id)
        {
            var user =await userService.FindById(id);
            var user1 = UserBuilder.ToEntity(user);
            var user2 = new User
            {
                Id = user.Id,
                Username = user.Username,
                Type = user.Type,
                Name = user.Name
            };
          await  userService.DeleteUser(user2);
            return Ok(user1);
        }
    }
}
