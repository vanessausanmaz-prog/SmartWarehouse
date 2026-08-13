using SmartWarehouse.Entities;

namespace SmartWarehouse.DataAccess.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByUsernameAsync(string username);
    }
}