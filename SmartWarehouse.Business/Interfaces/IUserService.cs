using SmartWarehouse.Domain.Entities;

namespace SmartWarehouse.Business.Interfaces
{
    public interface IUserService
    {
        Task<User?> GetByUsernameAsync(string username);
    }
}