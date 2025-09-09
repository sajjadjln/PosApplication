using PoseLibrary.Models;

namespace PoseLibrary.DataAccess.CsvHandling.CsvConvertor;

public class CardCsvConvertor : ICsvConvertor<CardModel>
{
    public string CsvModelToString(CardModel model)
    {
        return $"{model.Id},{model.CardNumber},{model.DateMonth},{model.DateYear},{model.Cvv2}";
    }

    public List<string> CsvModelToString(List<CardModel> cardModels)
    {
        return cardModels
            .Select(model => $"{model.Id},{model.CardNumber},{model.DateMonth},{model.DateYear},{model.Cvv2}")
            .ToList();
    }

    public List<CardModel> StringToCsvModel(List<string> csvModel)
    {
        var models = new List<CardModel>();
        var card = new CardModel();

        foreach (var line in csvModel)
        {
            var cols = line.Split(',');
            card.Id = int.Parse(cols[0]);
            card.CardNumber = cols[1];
            card.DateMonth = int.Parse(cols[2]);
            card.DateYear = int.Parse(cols[3]);
            card.Cvv2 = int.Parse(cols[4]);

            models.Add(card);
        }

        return models;

    }
}