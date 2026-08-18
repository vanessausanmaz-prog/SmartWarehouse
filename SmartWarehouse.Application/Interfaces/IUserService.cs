using SmartWarehouse.Domain.Entities;

namespace SmartWarehouse.Application.Interfaces
{
    public interface IUserService
    {
        Task<User?> GetByUsernameAsync(string username);
    }
}