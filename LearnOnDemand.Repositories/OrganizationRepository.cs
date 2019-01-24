using LearnOnDemand.Interfaces;
using LearnOnDemand.Models;
using LearnOnDemand.Repositories.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnOnDemand.Repositories
{
    public class OrganizationRepository : IOrganizationRepository
    {
        private readonly LearnOnDemandContext _context;

        public OrganizationRepository(LearnOnDemandContext context)
        {
            _context = context;
        }

        public async Task<List<OrganizationModel>> GetAllOrganizations()
        {
            return await _context.Organizations.Select(x => new OrganizationModel {
                Id = x.Id,
                Name = x.Name,
                Address = x.Address,
                City = x.City,
                State = x.State,
                Zip = x.Zip,
                Map = x.Map,
                Users = x.Users.Select(u => new UserModel { Id = u.Id, Name = u.Name, Email = u.Email, OrganizationKey= u.OrganizationKey}).ToList() }).ToListAsync();
        }

        public async Task<OrganizationModel> GetOrganization(int id)
        {
            var org = await _context.Organizations.Include(i => i.Users).SingleOrDefaultAsync(x => x.Id == id);

            if(org != null)
            {
                return new OrganizationModel
                {
                    Id = org.Id,
                    Name = org.Name,
                    Address = org.Address,
                    City = org.City,
                    State = org.State,
                    Zip = org.Zip,
                    Map = org.Map,
                    Users = org.Users.Select(u => new UserModel { Id = u.Id, Name = u.Name, Email = u.Email, OrganizationKey = u.OrganizationKey }).ToList()
                };
            }

            return new OrganizationModel { Users = new List<UserModel>() };
        }

        public async Task<int> CreateOrganization(OrganizationModel model)
        {
            var org = new Organizations { Name = model.Name, Address = model.Address, City = model.City, State = model.State, Zip = model.Zip, Map = model.Map };

            _context.Organizations.Add(org);

            await _context.SaveChangesAsync();

            return org.Id;
        }

        public async Task UpdateOrganization(OrganizationModel model)
        {
            var org = await _context.Organizations.FindAsync(model.Id);

            org.Name = model.Name;
            org.Address = model.Address;
            org.City = model.City;
            org.State = model.State;
            org.Zip = model.Zip;
            org.Map = model.Map;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteOrganization(int id)
        {
            var org = await _context.Organizations.Include(i => i.Users).SingleOrDefaultAsync(x => x.Id == id);

            if (org != null)
            {
                foreach (var user in org.Users)
                {
                    _context.Users.Remove(user);
                }

                _context.Organizations.Remove(org);

                await _context.SaveChangesAsync();
            }
        }
    }
}
