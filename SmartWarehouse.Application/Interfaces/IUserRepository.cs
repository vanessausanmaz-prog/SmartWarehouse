using SmartWarehouse.Domain.Entities;

namespace SmartWarehouse.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByUsernameAsync(string username);
    }
}