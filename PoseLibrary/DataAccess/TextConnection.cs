using PoseLibrary.DataAccess.CsvHandling;
using PoseLibrary.Models;

namespace PoseLibrary.DataAccess
{
    public class TextConnection : IDataConnection
    {
        public const string CardFile = "CardModel.csv";
        public const string TransactionFile = "Transactions.csv";
        public const string PasswordFile = "Password.csv";

        public CardModel CreateCard(CardModel model)
        {
            //load the text file and convert it to CardModel
            var cardModel = CardFile.FullFilePath().LoadFile().ConvertFileToModel(new CardCsvConvertor());

            // find the max id
            int CurrentId = 1;

            if (cardModel.Count > 0)
            {
                CurrentId = cardModel.OrderByDescending(x => x.Id).First().Id + 1;
            }

            model.Id = CurrentId;

            // add the new record with new id
            cardModel.Add(model);
            cardModel.SaveToFile(new CardCsvConvertor(), CardFile);
            return model;
        }

        public TransactionModel Transaction(TransactionModel model)
        {
            //load the text file and convert it to TransactionModel
            var transactionModel = TransactionFile.FullFilePath().LoadFile()
                .ConvertFileToModel(new TransactionCsvConvertor());
            // find the max id
            int CurrentId = 1;
            if (transactionModel.Count > 0)
            {
                CurrentId = transactionModel.OrderByDescending(x => x.Id).First().Id + 1;
            }

            model.Id = CurrentId;

            // add the new record with new id
            transactionModel.Add(model);

            transactionModel.SaveToFile(new TransactionCsvConvertor(), TransactionFile);

            return model;
        }

        public PasswordModel CreatePassword(PasswordModel model)
        {
            //load the text file and convert it to PasswordModel
            var password = PasswordFile.FullFilePath().LoadFile().ConvertFileToModel(new PasswordCsvConvertor());
            // find the max id
            int CurrentId = 1;
            if (password.Count > 0)
            {
                CurrentId = password.OrderByDescending(x => x.Id).First().Id + 1;
            }

            model.Id = CurrentId;

            // add the new record with new id
            password.Add(model);

            password.SaveToFile(new PasswordCsvConvertor(), PasswordFile);

            return model;
        }
    }
}