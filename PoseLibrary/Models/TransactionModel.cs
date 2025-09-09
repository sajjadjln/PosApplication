namespace PoseLibrary.Models
{
    public class TransactionModel(decimal amount, string? state)
    {
        // consider making the id required
        public int Id { get; set; }
        public decimal Amount { get; set; } = amount;
        public string? State { get; set; } = state;
    }
}