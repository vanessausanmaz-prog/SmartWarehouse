namespace SmartWarehouse.Domain.Entities
{
    public class StockMovement
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; } = null!;

        public string TransactionType { get; set; } = string.Empty;

        public int Quantity { get; set; }

        public DateTime Date { get; set; }

        public string? Description { get; set; }
    }
}