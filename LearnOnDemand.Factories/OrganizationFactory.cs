using LearnOnDemand.Entities;
using LearnOnDemand.Models;
using System;
using System.Linq;

namespace LearnOnDemand.Factories
{
    public class OrganizationFactory
    {
        public static OrganizationModel GetOrganizationModel(Organizations organization)
        {
            if (organization == null) { return new OrganizationModel(); }

            return new OrganizationModel { Id = organization.Id, Name = organization.Name, Address = organization.Address, City = organization.City, State = organization.State, Zip = organization.Zip, Users = UserFactory.GetUserModel(organization.Users) };
        }

        public static Organizations GetOrganization(OrganizationModel model)
        {
            if (model == null) { return new Organizations(); }

            return new Organizations { Id = model.Id, Name = model.Name, Address = model.Address, City = model.City, State = model.State, Zip = model.Zip, Users = UserFactory.GetUser(model.Users) };
        }
    }
}
