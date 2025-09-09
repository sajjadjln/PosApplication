using PoseLibrary.Models;

namespace PoseLibrary.DataAccess.CsvHandling;

public class TransactionCsvConvertor : ICsvConvertor<TransactionModel>
{
    public string CsvModelToString(TransactionModel model)
    {
        return $"{model.Id},{model.Amount},{model.State}";
    }

    public List<string> CsvModelToString(List<TransactionModel> model)
    {
        var lines = new List<string>();
        foreach (var item in model)
        {
            lines.Add($"{item.Id},{item.Amount},{item.State}");
        }

        return lines;
    }

    public List<TransactionModel> StringToCsvModel(List<string> csvModel)
    {
        var output = new List<TransactionModel>();
        var transactionModel = new TransactionModel();

        foreach (var line in csvModel)
        {
            var cols = line.Split(',');

            transactionModel.Id = int.Parse(cols[0]);
            transactionModel.Amount = decimal.Parse(cols[1]);
            transactionModel.State = cols[2];


            output.Add(transactionModel);
        }

        return output;
    }
}