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
    public class OrganizationController : ControllerBase
    {
        private readonly IOrganizationService _organizationService;

        public OrganizationController(IOrganizationService organizationService)
        {
            _organizationService = organizationService;
        }

        [HttpGet]
        public async Task<IEnumerable<OrganizationModel>> Get()
        {
            return await _organizationService.GetAllOrganizations();
        }

        [HttpGet("{id}")]
        public async Task<OrganizationModel> Get(int id)
        {
            return await _organizationService.GetOrganization(id);
        }

        [HttpPost]
        public async Task<int> Post([FromBody] OrganizationModel model)
        {
            return await _organizationService.CreateOrganization(model);
        }

        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] OrganizationModel model)
        {
            await _organizationService.UpdateOrganization(model);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _organizationService.DeleteOrganization(id);
        }
    }
}
