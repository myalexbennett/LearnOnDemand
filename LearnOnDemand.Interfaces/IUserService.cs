using LearnOnDemand.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LearnOnDemand.Interfaces
{
    public interface IUserService
    {
        Task<UserModel> GetUser(int id);
        Task<int> CreateUser(UserModel model);
        Task UpdateUser(UserModel model);
        Task DeleteUser(int id);
    }
}
