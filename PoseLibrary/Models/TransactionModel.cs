namespace PoseLibrary.Models
{
    public class TransactionModel
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string? State { get; set; }
    }
}