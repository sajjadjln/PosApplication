namespace PoseLibrary.DataAccess.CsvHandling;

public interface ICsvConvertor<T>
{
    List<string> CsvModelToString(List<T> model);
    List<T> StringToCsvModel(List<string> csvModel);
}