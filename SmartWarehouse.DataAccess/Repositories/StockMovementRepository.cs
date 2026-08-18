using Microsoft.EntityFrameworkCore;
using SmartWarehouse.DataAccess;
using SmartWarehouse.DataAccess.Interfaces;
using SmartWarehouse.Domain.Entities;

namespace SmartWarehouse.DataAccess.Repositories
{
    public class StockMovementRepository : IStockMovementRepository
    {
        private readonly ApplicationDbContext _context;

        public StockMovementRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<StockMovement>> GetAllAsync()
        {
            return await _context.StockMovements
                .Include(x => x.Product)
                .ToListAsync();
        }

        public async Task<StockMovement?> GetByIdAsync(int id)
        {
            return await _context.StockMovements
                .Include(x => x.Product)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddAsync(StockMovement stockMovement)
        {
            await _context.StockMovements.AddAsync(stockMovement);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var stockMovement = await _context.StockMovements.FindAsync(id);

            if (stockMovement != null)
            {
                _context.StockMovements.Remove(stockMovement);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteSelectedAsync(List<int> selectedIds)
        {
            var stockMovements = await _context.StockMovements
                .Where(x => selectedIds.Contains(x.Id))
                .ToListAsync();

            _context.StockMovements.RemoveRange(stockMovements);
            await _context.SaveChangesAsync();
        }
    }
}