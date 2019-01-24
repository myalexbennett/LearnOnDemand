using LearnOnDemand.Interfaces;
using LearnOnDemand.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LearnOnDemand.Services
{
    public class OrganizationService : IOrganizationService
    {
        private readonly IOrganizationRepository _organizationRepository;

        public OrganizationService(IOrganizationRepository organizationRepository)
        {
            _organizationRepository = organizationRepository;
        }

        public async Task<List<OrganizationModel>> GetAllOrganizations()
        {
            return await _organizationRepository.GetAllOrganizations();
        }

        public async Task<OrganizationModel> GetOrganization(int id)
        {
            return await _organizationRepository.GetOrganization(id);
        }

        public async Task<int> CreateOrganization(OrganizationModel model)
        {
            return await _organizationRepository.CreateOrganization(model);
        }

        public async Task UpdateOrganization(OrganizationModel model)
        {
            await _organizationRepository.UpdateOrganization(model);
        }

        public async Task DeleteOrganization(int id)
        {
            await _organizationRepository.DeleteOrganization(id);
        }
    }
}
