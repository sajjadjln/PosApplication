using PoseLibrary.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoseLibrary.DataAccess.TextHelpers
{
    public static class TextConnectorProcessor
    {
        /// <summary>
        /// this extension method asks for the filename and gives you the full path
        /// </summary>
        public static string FullFilePath(this string fileName)
        {
            // adding a key=filePath and its value to AppSetting
            /*var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings.Add("filePath", "F:\\c#_projects\\POS_project\\Data");
            config.Save(ConfigurationSaveMode.Modified);

            return $"{ConfigurationManager.AppSettings["filePath"]}\\{fileName}";*/
            return $"F:\\c#_projects\\POS_project\\Data\\{fileName}";
        }

        /// <summary>
        /// checks if the files exist and load the file
        /// </summary>
        public static List<string> LoadFile(this string fileName)
        {
            if (!File.Exists(fileName))
            {
                return new List<string>();
            }

            return File.ReadLines(fileName).ToList();
        }

        /// <summary>
        /// takes a list of string containing our file information
        /// convert every line to a model of card
        /// </summary>
        public static List<CardModel> ConvertToCardModel(this List<string> lines)
        {
            List<CardModel> output = new List<CardModel>();
            foreach (var line in lines)
            {
                string[] cols = line.Split(',');
                CardModel card = new CardModel();

                card.Id = int.Parse(cols[0]);
                card.CardNumber = cols[1];
                card.DateMonth = int.Parse(cols[2]);
                card.DateYear = int.Parse(cols[3]);
                card.Cvv2 = int.Parse(cols[4]);

                output.Add(card);
            }

            return output;
        }

        public static List<TransactionModel> ConvertToTransactionModel(this List<string> lines)
        {
            List<TransactionModel> output = new List<TransactionModel>();
            foreach (var line in lines)
            {
                string[] cols = line.Split(',');
                TransactionModel Transaction = new TransactionModel();

                Transaction.Id = int.Parse(cols[0]);
                Transaction.Amount = decimal.Parse(cols[1]);
                Transaction.State = cols[2];


                output.Add(Transaction);
            }

            return output;
        }

        public static List<PasswordModel> ConvertToPasswordModel(this List<string> lines)
        {
            List<PasswordModel> output = new List<PasswordModel>();
            PasswordModel Password = new PasswordModel();
            foreach (var line in lines)
            {
                string[] cols = line.Split(',');
                Password.Id = int.Parse(cols[0]);
                Password.Password = cols[1];
                Password.DateTime = DateTime.Parse(cols[2]);

                output.Add(Password);
            }

            return output;
        }

        /// <summary>
        /// we take our models and convert them to a list of strings
        /// and we take filename and convert it to the full path
        /// and we write our list to the file
        /// </summary>
        public static void SaveToCardFile(this List<CardModel> models, string fileName)
        {
            List<string> lines = new List<string>();

            foreach (CardModel p in models)
            {
                lines.Add($"{p.Id},{p.CardNumber},{p.DateMonth},{p.DateYear},{p.Cvv2}");
            }

            File.WriteAllLines(fileName.FullFilePath(), lines);
        }

        public static void SaveToTransactionFile(this List<TransactionModel> models, string fileName)
        {
            List<string> lines = new List<string>();

            foreach (TransactionModel p in models)
            {
                lines.Add($"{p.Id},{p.Amount},{p.State}");
            }

            File.WriteAllLines(fileName.FullFilePath(), lines);
        }

        public static void SaveToPasswordFile(this List<PasswordModel> models, string fileName)
        {
            List<string> lines = new List<string>();

            foreach (PasswordModel p in models)
            {
                lines.Add($"{p.Id},{p.Password},{p.DateTime}");
            }

            File.WriteAllLines(fileName.FullFilePath(), lines);
        }
    }
}