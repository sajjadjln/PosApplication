using PoseLibrary;
using PoseLibrary.DataAccess;
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
                    ConvertToTransaction ToTransaction = new ConvertToTransaction(Amount, "succeed");
                    TextConnection TransactionTextFile = new TextConnection();
                    TransactionTextFile.Transaction(ToTransaction);
                    FlagSaveInfo = 1;
                }
                else
                {
                    Console.WriteLine("transaction failed (your password is wrong or expired)");
                    ConvertToTransaction ToTransaction = new ConvertToTransaction(Amount, "failed");
                    TextConnection TransactionTextFile = new TextConnection();
                    TransactionTextFile.Transaction(ToTransaction);
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