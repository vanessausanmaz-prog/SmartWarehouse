using SmartWarehouse.Domain.Entities;

namespace SmartWarehouse.Business.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByUsernameAsync(string username);
    }
}