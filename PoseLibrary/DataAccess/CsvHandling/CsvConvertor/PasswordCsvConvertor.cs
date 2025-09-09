using PoseLibrary.Models;

namespace PoseLibrary.DataAccess.CsvHandling.CsvConvertor;

public class PasswordCsvConvertor : ICsvConvertor<PasswordModel>
{
    public string CsvModelToString(PasswordModel model)
    {
        return $"{model.Id},{model.Password},{model.DateTime}";
    }

    public List<string> CsvModelToString(List<PasswordModel> model)
    {
        var lines = new List<string>();
        foreach (var item in model)
        {
            lines.Add($"{item.Id},{item.Password},{item.DateTime}");
        }

        return lines;
    }

    public List<PasswordModel> StringToCsvModel(List<string> csvModel)
    {
        var models = new List<PasswordModel>();
        foreach (var item in csvModel)
        {
            var cols = item.Split(',');
            var password = new PasswordModel(cols[1], DateTime.Parse(cols[2]))
            {
                Id = int.Parse(cols[0])
            };
            models.Add(password);
        }

        return models;
    }
}