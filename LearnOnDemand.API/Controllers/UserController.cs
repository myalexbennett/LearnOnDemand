using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnOnDemand.Interfaces;
using LearnOnDemand.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearnOnDemand.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        public async Task<UserModel> Get(int id)
        {
            return await _userService.GetUser(id);
        }

        [HttpPost]
        public async Task<int> Post([FromBody] UserModel model)
        {
            return await _userService.CreateUser(model);
        }

        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] UserModel model)
        {
            await _userService.UpdateUser(model);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _userService.DeleteUser(id);
        }
    }
}
