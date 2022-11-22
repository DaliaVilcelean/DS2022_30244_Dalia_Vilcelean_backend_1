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
    public class UserDeviceController : ControllerBase
    {


        private UserDeviceService userDeviceService;

        public UserDeviceController(UserDeviceService userDeviceService)
        {
            this.userDeviceService = userDeviceService;
        }


        [HttpPost]
        [Route("AddUserDevice")]
        public async Task<ActionResult> AddUserDevice([FromBody] UserDevice u)
        {
            var userDevice =await userDeviceService.AddUserDevice(u);
            return Ok(userDevice);
        }

        [HttpGet]
        [Route("FilterByUserId/{id}")]
        public async Task<ActionResult> FilterByUsers([FromRoute] Guid id)
        {
            var userDevice = await userDeviceService.FilterByUser(id);
            return Ok(userDevice);
        }


    }
}
