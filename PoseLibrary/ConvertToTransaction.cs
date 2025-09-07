using PoseLibrary.Models;

namespace PoseLibrary
{
    public class ConvertToTransaction : TransactionModel
    {
        public ConvertToTransaction(decimal amount, string state)
        {
            Amount = amount;
            State = state;
        }
    }
}