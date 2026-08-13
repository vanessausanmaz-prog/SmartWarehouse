using Microsoft.EntityFrameworkCore;
using SmartWarehouse.DataAccess;
using SmartWarehouse.DataAccess.Interfaces;
using SmartWarehouse.Entities;

namespace SmartWarehouse.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User?> GetByUsernameAsync(string username)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Username == username);
        }
    }
}