using PoseLibrary.DataAccess.CsvHandling.CsvConvertor;

namespace PoseLibrary.DataAccess
{
    public static class TextConnectorProcessor
    {
        public static string FullFilePath(this string fileName)
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), fileName);
        }

        public static int GetNextIdFromLastLine(string filePath)
        {
            if (!File.Exists(filePath)) return 1;

            var lastLine = File.ReadLines(filePath).LastOrDefault();
            if (string.IsNullOrEmpty(lastLine)) return 1;

            // Parse the ID from the first column (assuming CSV format)
            var parts = lastLine.Split(',');
            if (parts.Length > 0 && int.TryParse(parts[0], out var lastId))
                return lastId + 1;

            return 1;
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

        public static void AddToFile<T>(this T models, ICsvConvertor<T> convertor, string fileName)
        {
            var stringFormat = convertor.CsvModelToString(models);
            File.AppendAllLines(fileName.FullFilePath(), new[] { stringFormat });
        }
    }
}