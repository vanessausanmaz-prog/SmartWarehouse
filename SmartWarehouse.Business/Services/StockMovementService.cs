using SmartWarehouse.Business.Interfaces;
using SmartWarehouse.Domain.Entities;

namespace SmartWarehouse.Business.Services
{
    public class StockMovementService : IStockMovementService
    {
        private readonly IStockMovementRepository _stockMovementRepository;

        public StockMovementService(IStockMovementRepository stockMovementRepository)
        {
            _stockMovementRepository = stockMovementRepository;
        }

        public async Task<List<StockMovement>> GetAllAsync()
        {
            return await _stockMovementRepository.GetAllAsync();
        }

        public async Task<StockMovement?> GetByIdAsync(int id)
        {
            return await _stockMovementRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(StockMovement stockMovement)
        {
            await _stockMovementRepository.AddAsync(stockMovement);
        }

        public async Task DeleteAsync(int id)
        {
            await _stockMovementRepository.DeleteAsync(id);
        }

        public async Task DeleteSelectedAsync(List<int> selectedIds)
        {
            await _stockMovementRepository.DeleteSelectedAsync(selectedIds);
        }
    }
}