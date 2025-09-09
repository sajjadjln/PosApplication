using PoseLibrary.Models;

namespace PoseLibrary.DataAccess.CsvHandling.AddModelToCsv;

public class AddNewTransactionToCsv : IDataConnection<TransactionModel>
{
    public TransactionModel AddModel(TransactionModel model)
    {
        var lastId = TextConnectorProcessor.GetNextIdFromLastLine(GlobalSettings.TransactionFile.FullFilePath());
        model.Id = lastId;
        model.AddToFile(new TransactionCsvConvertor(), GlobalSettings.TransactionFile);
        return model;
    }
}