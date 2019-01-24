using LearnOnDemand.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LearnOnDemand.Interfaces
{
    public interface ILearnOnDemandClient
    {
        Task<List<OrganizationModel>> GetOrganizations();
        Task<OrganizationModel> GetOrganization(int id);
        Task<int> CreateOrganization(OrganizationModel model);
        Task UpdateOrganization(OrganizationModel model);
        Task DeleteOrganization(int id);
        Task<UserModel> GetUser(int id);
        Task UpdateUser(UserModel model);
        Task<int> CreateUser(UserModel model);
        Task DeleteUser(int id);
    }
}
