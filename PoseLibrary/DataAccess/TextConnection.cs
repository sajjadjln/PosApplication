using PoseLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PoseLibrary.DataAccess.TextHelpers;

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
            List<CardModel> Cards = CardFile.FullFilePath().LoadFile().ConvertToCardModel();

            // find the max id
            int CurrentId = 1;

            if (Cards.Count > 0)
            {
                CurrentId = Cards.OrderByDescending(x => x.Id).First().Id + 1;
            }
            model.Id = CurrentId;

            // add the new record with new id
            Cards.Add(model);

            Cards.SaveToCardFile(CardFile);

            return model;
        }
        public TransactionModel Transaction(TransactionModel model)
        {
            //load the text file and convert it to TransactionModel
            List<TransactionModel> Transactions = TransactionFile.FullFilePath().LoadFile().ConvertToTransactionModel();
            // find the max id
            int CurrentId = 1;
            if (Transactions.Count > 0)
            {
                CurrentId = Transactions.OrderByDescending(x => x.Id).First().Id + 1;
            }
            model.Id = CurrentId;

            // add the new record with new id
            Transactions.Add(model);

            Transactions.SaveToTransactionFile(TransactionFile);

            return model;
        }
        public PasswordModel CreatePassword(PasswordModel model)
        {
            //load the text file and convert it to TransactionModel
            List<PasswordModel> Password = PasswordFile.FullFilePath().LoadFile().ConvertToPasswordModel();
            // find the max id
            int CurrentId = 1;
            if (Password.Count > 0)
            {
                CurrentId = Password.OrderByDescending(x => x.Id).First().Id + 1;
            }
            model.Id = CurrentId;

            // add the new record with new id
            Password.Add(model);

            Password.SaveToPasswordFile(PasswordFile);

            return model;
        }

    }
}
