using PoseLibrary.DataAccess.CsvHandling.CsvConvertor;
using PoseLibrary.Models;

namespace PoseLibrary.DataAccess.CsvHandling.AddModelToCsv;

public class AddNewCardModelToCsv : IDataConnection<CardModel>
{
    public CardModel AddModel(CardModel model)
    {
        var lastId = TextConnectorProcessor.GetNextIdFromLastLine(GlobalSettings.CardFile.FullFilePath());
        model.Id = lastId;
        model.AddToFile(new CardCsvConvertor(), GlobalSettings.CardFile);
        return model;
    }
}