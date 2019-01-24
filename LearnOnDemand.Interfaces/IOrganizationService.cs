using LearnOnDemand.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LearnOnDemand.Interfaces
{
    public interface IOrganizationService
    {
        Task<List<OrganizationModel>> GetAllOrganizations();
        Task<OrganizationModel> GetOrganization(int id);
        Task<int> CreateOrganization(OrganizationModel model);
        Task UpdateOrganization(OrganizationModel model);
        Task DeleteOrganization(int id);
    }
}
