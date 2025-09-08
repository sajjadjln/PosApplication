using PoseLibrary.DataAccess.CsvHandling;

namespace PoseLibrary.DataAccess
{
    public static class TextConnectorProcessor
    {
        public static string FullFilePath(this string fileName)
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), fileName);
        }

        public static List<string> LoadFile(this string fileName)
        {
            if (!File.Exists(fileName))
            {
                return new List<string>();
            }

            return File.ReadLines(fileName).ToList();
        }

        public static List<T> ConvertFileToModel<T>(this List<string> items, ICsvConvertor<T> convertor) where T : class
        {
            return convertor.StringToCsvModel(items);
        }

        /// <summary>
        /// we take our models and convert them to a list of strings
        /// we take filename and convert it to the full path
        /// we write our list to the file
        /// </summary>
        public static void SaveToFile<T>(this List<T> models, ICsvConvertor<T> convertor, string fileName)
            where T : class
        {
            var stringFormat = convertor.CsvModelToString(models);
            File.WriteAllLines(fileName.FullFilePath(), stringFormat);
        }
    }
}