using LearnOnDemand.Entities;
using LearnOnDemand.Factories;
using LearnOnDemand.Interfaces;
using LearnOnDemand.Models;
using System;
using System.Collections.Generic;
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
            return UserFactory.GetUserModel(await _context.Users.FindAsync(id));
        }

        public async Task<int> CreateUser(UserModel model)
        {
            try
            {
                var user = UserFactory.GetUser(model);

                _context.Users.Add(user);

                await _context.SaveChangesAsync();

                return user.Id;
            }
            catch(Exception ex)
            {
                var message = ex.Message;
            }

            return 1;
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
