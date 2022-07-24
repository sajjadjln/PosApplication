using PoseLibrary;
using PoseLibrary.DataAccess;
using PoseLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosePassword
{
    public class TransactionProccess
    {
        public int FlagSaveInfo { get; set; }
        public TransactionProccess(List<PasswordModel> Password, string? InputPassword,decimal Amount) 
        {
            int CurrentId = Password.OrderByDescending(x => x.Id).First().Id;
            foreach (var pass in Password)
            {
                if (pass.Id == CurrentId)
                {
                    if (pass.Password == InputPassword)
                    {
                        Console.WriteLine("transaction succeed");
                        ConvertToTransaction ToTransaction = new ConvertToTransaction(Amount, "succeed");
                        TextConnection TransactionTextFile = new TextConnection();
                        TransactionTextFile.Transaction(ToTransaction);
                        FlagSaveInfo = 1;
                    }
                    else
                    {
                        Console.WriteLine("transaction failed");
                        ConvertToTransaction ToTransaction = new ConvertToTransaction(Amount, "failed");
                        TextConnection TransactionTextFile = new TextConnection();
                        TransactionTextFile.Transaction(ToTransaction);
                    }

                }
            }
        }
        public TransactionProccess(ConvertCardType cardModel)
        {
                Console.WriteLine("do you want to save your card enterd information\n1.Yes\n2.No");
                int InputResult = Convert.ToInt32(Console.ReadLine());
                if (InputResult == 1)
                {
                    TextConnection CardtextFile = new TextConnection();
                    CardtextFile.CreatCard(cardModel);
                }
            
        }
    }
}
