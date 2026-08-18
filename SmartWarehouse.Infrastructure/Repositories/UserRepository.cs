using Microsoft.EntityFrameworkCore;
using SmartWarehouse.Infrastructure;
using SmartWarehouse.Application.Interfaces;
using SmartWarehouse.Domain.Entities;


namespace SmartWarehouse.Infrastructure.Repositories
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