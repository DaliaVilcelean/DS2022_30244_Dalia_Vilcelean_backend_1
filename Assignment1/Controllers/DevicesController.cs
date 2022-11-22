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
    public class DevicesController : ControllerBase
    {

        private DeviceService deviceService;

        public DevicesController(DeviceService deviceService)
        {
            this.deviceService = deviceService;
        }

        [HttpGet]
        [Route("FindAllDevices")]
        public async Task<ActionResult<DeviceDTO>> FindAllDevices()
        {

            var devices = await deviceService.FindAllDevices();
            return Ok(devices.ToList());
        }
        [HttpPost]
        [Route("AddDevice")]
 
        public async Task<ActionResult> AddDevice([FromBody] Devices d)
        {
            var device =await deviceService.AddDevice(d);
            return Ok(device);
        }

        [HttpDelete]
        [Route("DeleteDevice/{id}")]
    
        public async Task<ActionResult<Devices>> DeleteDeviceById([FromRoute] Guid id)
        {
            var device =await deviceService.FindById(id);
            var device1 = DeviceBuilder.ToEntity(device);
           await deviceService.DeleteDevice(device1);
            return Ok(device1);
        }

        [HttpPost]
        [Route("UpdateDevice")]
        public async Task<ActionResult<DeviceDTO>> UpdateDevice([FromBody] Devices d)
        {
            var device =await deviceService.UpdateDevice(d);
            return Ok(device);
        }

        

        [HttpGet]
        [Route("FindDeviceById/{id}")]
        public async Task<ActionResult<Devices>> FindDeviceById([FromRoute] Guid id)
        {
            var device = await deviceService.FindById(id);
            return Ok(device);
        }

    }
}
