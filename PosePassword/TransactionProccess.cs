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
    public class TransactionProcess
    {
        public int FlagSaveInfo { get; set; }
        public TransactionProcess(List<PasswordModel> Password, string? InputPassword,decimal Amount) 
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
        public TransactionProcess(ConvertCardType cardModel)
        {
                Console.WriteLine("do you want to save your card entered information\n1.Yes\n2.No");
                int InputResult = Convert.ToInt32(Console.ReadLine());
                if (InputResult == 1)
                {
                    TextConnection CardTextFile = new TextConnection();
                    CardTextFile.CreateCard(cardModel);
                }

        }
    }
}
