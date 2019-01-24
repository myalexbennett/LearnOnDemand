using LearnOnDemand.Interfaces;
using LearnOnDemand.Models;
using LearnOnDemand.Repositories.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnOnDemand.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly LearnOnDemandContext _context;

        public UserRepository(LearnOnDemandContext context)
        {
            _context = context;
        }

        public async Task<UserModel> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            return new UserModel { Id = user.Id, OrganizationKey = user.OrganizationKey, Name = user.Name, Email = user.Email, };
        }

        public async Task<int> CreateUser(UserModel model)
        {
            var user = new Users { Name = model.Name, Email = model.Email, OrganizationKey = model.OrganizationKey };

            _context.Users.Add(user);

            await _context.SaveChangesAsync();

            return user.Id;
        }

        public async Task UpdateUser(UserModel model)
        {
            var user = await _context.Users.FindAsync(model.Id);

            user.Name = model.Name;
            user.Email = model.Email;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            _context.Users.Remove(user);

            await _context.SaveChangesAsync();
        }
    }
}
