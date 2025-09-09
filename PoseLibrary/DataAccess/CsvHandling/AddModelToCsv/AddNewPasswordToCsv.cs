using PoseLibrary.Models;

namespace PoseLibrary.DataAccess.CsvHandling.AddModelToCsv;

public class AddNewPasswordToCsv : IDataConnection<PasswordModel>
{
    public PasswordModel AddModel(PasswordModel model)
    {
        var lastId = TextConnectorProcessor.GetNextIdFromLastLine(GlobalSettings.PasswordFile.FullFilePath());
        model.Id = lastId;
        model.AddToFile(new PasswordCsvConvertor(), GlobalSettings.TransactionFile);
        return model;
    }
}