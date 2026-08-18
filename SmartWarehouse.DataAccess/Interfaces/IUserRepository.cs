using SmartWarehouse.Domain.Entities;

namespace SmartWarehouse.DataAccess.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByUsernameAsync(string username);
    }
}