using LearnOnDemand.Entities;
using LearnOnDemand.Models;
using System.Collections.Generic;
using System.Linq;

namespace LearnOnDemand.Factories
{
    public class UserFactory
    {
        public static UserModel GetUserModel(Users user)
        {
            if (user == null) { return new UserModel(); }

            return new UserModel { Id = user.Id, OrganizationKey = user.OrganizationKey, Name = user.Name, Email = user.Email };
        }

        public static List<UserModel> GetUserModel(IEnumerable<Users> users)
        {
            var model = new List<UserModel>();

            foreach(var user in users ?? Enumerable.Empty<Users>())
            {
                model.Add(GetUserModel(user));
            }

            return model;
        }

        public static Users GetUser(UserModel model)
        {
            if (model == null) { return new Users(); }

            return new Users { Id = model.Id, OrganizationKey = model.OrganizationKey, Name = model.Name, Email = model.Email };
        }

        public static List<Users> GetUser(IEnumerable<UserModel> models)
        {
            var user = new List<Users>();

            foreach (var model in models ?? Enumerable.Empty<UserModel>())
            {
                user.Add(GetUser(model));
            }

            return user;
        }

    }
}
