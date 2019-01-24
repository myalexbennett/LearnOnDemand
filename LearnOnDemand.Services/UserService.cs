using LearnOnDemand.Interfaces;
using LearnOnDemand.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LearnOnDemand.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ISendGridService _sendGridService;

        public UserService(IUserRepository userRepository, ISendGridService sendGridService)
        {
            _userRepository = userRepository;
            _sendGridService = sendGridService;
        }

        public async Task<UserModel> GetUser(int id)
        {
            return await _userRepository.GetUser(id);
        }

        public async Task<int> CreateUser(UserModel model)
        {
            await _sendGridService.SendMail(model.Name, model.Email);

            return await _userRepository.CreateUser(model);
        }

        public async Task UpdateUser(UserModel model)
        {
            await _userRepository.UpdateUser(model);
        }

        public async Task DeleteUser(int id)
        {
            await _userRepository.DeleteUser(id);
        }
    }
}
