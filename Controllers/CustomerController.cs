using LearnAPI.Modal;
using LearnAPI.Service;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.AspNetCore.Authorization;

namespace LearnAPI.Controllers
{
    [Authorize]
    //[DisableCors]
    [EnableRateLimiting("fixedwindow")]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService service;

        public CustomerController(ICustomerService service)
        {
            this.service = service;
        }

        //[EnableCors("corspolicy1")]
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var data = await this.service.Getall();
            if(data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        [DisableRateLimiting]
        [HttpGet("Getbycode")]
        public async Task<IActionResult> Getbycode(string code)
        {
            var data = await this.service.Getbycode(code);
            if(data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(CustomerModal _data)
        {
            var data = await this.service.Create(_data);
            return Ok(data);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(CustomerModal _data,string code)
        {
            var data = await this.service.Update(_data,code);
            return Ok(data);
        }

        [HttpDelete("Remove")]
        public async Task<IActionResult> Remove(string code)
        {
            var data = await this.service.Remove(code);
            return Ok(data);
        }
    }
}