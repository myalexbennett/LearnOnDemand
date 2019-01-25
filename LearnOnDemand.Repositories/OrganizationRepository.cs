using LearnOnDemand.Entities;
using LearnOnDemand.Factories;
using LearnOnDemand.Interfaces;
using LearnOnDemand.Models;
using Microsoft.EntityFrameworkCore;
using System;
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
            return await _context.Organizations.Select(x => OrganizationFactory.GetOrganizationModel(x)).ToListAsync();
        }

        public async Task<OrganizationModel> GetOrganization(int id)
        {
            return OrganizationFactory.GetOrganizationModel(await _context.Organizations.Include(i => i.Users).SingleOrDefaultAsync(x => x.Id == id));
        }

        public async Task<int> CreateOrganization(OrganizationModel model)
        {
            try
            {
                var organization = OrganizationFactory.GetOrganization(model);

                _context.Organizations.Add(organization);

                await _context.SaveChangesAsync();

                return organization.Id;
            }
            catch(Exception ex)
            {
                var message = ex.Message;
            }

            return 1;
        }

        public async Task UpdateOrganization(OrganizationModel model)
        {
            var organization = await _context.Organizations.FindAsync(model.Id);

            organization.Name = model.Name;
            organization.Address = model.Address;
            organization.City = model.City;
            organization.State = model.State;
            organization.Zip = model.Zip;

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
