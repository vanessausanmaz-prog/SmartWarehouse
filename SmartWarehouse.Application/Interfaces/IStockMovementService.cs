using SmartWarehouse.Domain.Entities;

namespace SmartWarehouse.Application.Interfaces
{
    public interface IStockMovementService
    {
        Task<List<StockMovement>> GetAllAsync();
        Task<StockMovement?> GetByIdAsync(int id);
        Task AddAsync(StockMovement stockMovement);
        Task DeleteAsync(int id);
        Task DeleteSelectedAsync(List<int> selectedIds);
    }
}