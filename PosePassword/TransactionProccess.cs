using PoseLibrary.DataAccess.CsvHandling.AddModelToCsv;
using PoseLibrary.Models;

namespace PosePassword
{
    public class TransactionProcess
    {
        public int FlagSaveInfo { get; set; }

        public TransactionProcess(List<PasswordModel> Password, string? InputPassword, decimal Amount)
        {
            if (Password.Count == 0)
            {
                Console.WriteLine("please use the password generator first");
            }
            else
            {
                var CurrentPassword = Password.OrderByDescending(x => x.Id).Last();
                int res = DateTime.Compare(CurrentPassword.DateTime.AddMinutes(5), DateTime.Now);
                if (CurrentPassword.Password == InputPassword && res > 0)
                {
                    Console.WriteLine("transaction succeed");
                    var ToTransaction = new TransactionModel(Amount, "succeed");
                    AddNewTransactionToCsv TransactionTextFile = new AddNewTransactionToCsv();
                    TransactionTextFile.AddModel(ToTransaction);
                    FlagSaveInfo = 1;
                }
                else
                {
                    Console.WriteLine("transaction failed (your password is wrong or expired)");
                    var ToTransaction = new TransactionModel(Amount, "failed");
                    AddNewTransactionToCsv TransactionTextFile = new AddNewTransactionToCsv();
                    TransactionTextFile.AddModel(ToTransaction);
                }
            }
        }

        public TransactionProcess(CardModel cardModel)
        {
            Console.WriteLine("do you want to save your card entered information\n1.Yes\n2.No");
            int InputResult = Convert.ToInt32(Console.ReadLine());
            if (InputResult == 1)
            {
                AddNewCardModelToCsv CardTextFile = new AddNewCardModelToCsv();
                CardTextFile.AddModel(cardModel);
            }
        }
    }
}