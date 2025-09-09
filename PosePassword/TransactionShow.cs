using PoseLibrary;
using PoseLibrary.DataAccess;
using PoseLibrary.DataAccess.CsvHandling.CsvConvertor;

namespace PosePassword
{
    public class TransactionShow
    {
        public TransactionShow()
        {
            var transactionModel = GlobalSettings.TransactionFile.FullFilePath().LoadFile()
                .ConvertFileToModel(new TransactionCsvConvertor());
            if (transactionModel.Count == 0)
            {
                Console.WriteLine("there is no transaction");
            }

            foreach (var line in transactionModel)
            {
                Console.WriteLine($"ID: {line.Id}   Amount: {line.Amount}  Status: {line.State}");
            }
        }
    }
}