using PoseLibrary.DataAccess;
using PoseLibrary.DataAccess.TextHelpers;
using PoseLibrary.Models;
namespace PosePassword
{
    public class TransactionShow : TextConnection
    {
        public TransactionShow()
        {
            List<TransactionModel> ListTransactions = TransactionFile.FullFilePath().LoadFile().ConvertToTransactionModel();
            if(ListTransactions.Count == 0)
            {
                Console.WriteLine("there is no transaction");
            }
            foreach(var line in ListTransactions)
            {
                Console.WriteLine($"ID: {line.Id}   Amount: {line.Amount}  Status: {line.State}");
            }
        }
    }
}