namespace PoseLibrary.DataAccess.CsvHandling.CsvConvertor;

public interface ICsvConvertor<T>
{
    string CsvModelToString(T model);
    List<string> CsvModelToString(List<T> model);
    List<T> StringToCsvModel(List<string> csvModel);
}