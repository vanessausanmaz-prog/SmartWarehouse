using SmartWarehouse.Application.Interfaces;
using SmartWarehouse.Domain.Entities;

namespace SmartWarehouse.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User?> GetByUsernameAsync(string username)
        {
            return await _userRepository.GetByUsernameAsync(username);
        }
    }
}