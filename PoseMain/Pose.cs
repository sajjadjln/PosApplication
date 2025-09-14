using PoseLibrary.DataAccess;
using PoseLibrary.DataAccess.CsvHandling.AddModelToCsv;
using PoseLibrary.DataAccess.CsvHandling.CsvConvertor;
using PosePassword;

const string CardFile = "CardModel.csv";
const string PasswordFile = "Password.csv";

ShowMassage Input = new ShowMassage();
int InputSwitch = Input.PoseSwitch();

switch (InputSwitch)
{
    case 1: //use a save card
        var Money1 = new AmountInput();
        var cardShow = new ShowListCard();
        cardShow.ShowInfo();
        var cardModel = CardFile.FullFilePath().LoadFile().ConvertFileToModel(new CardCsvConvertor());
        foreach (var Card in cardModel)
        {
            if (Card.Id == cardShow.CardOption)
            {
                Console.WriteLine("Enter your password");
                string? InputPassword = Console.ReadLine();
//                CardValidator.ValidatePassword(InputPassword); for now the validation for password not work here till fix
                var password = PasswordFile.FullFilePath().LoadFile().ConvertFileToModel(new PasswordCsvConvertor());
                var storage = new AddNewTransactionToCsv();
                var service = new ProcessTransaction(storage);
                service.ProcessTransactionWithPassword(password, InputPassword, Money1.Amount);
            }
        }

        Console.Read();
        break;
    case 2: // entering info

        Console.Clear();
        var Money2 = new AmountInput();
        var convertedCardType = CardInput.CardInputInfo();
        Console.WriteLine("Enter your password");
        string? InputPassword2 = Console.ReadLine();
        //    Validation.ValidationPassword(InputPassword2);  for now the validation for password not work here till fix
        var passwordFileString2 = PasswordFile.FullFilePath().LoadFile();
        var password2 = passwordFileString2.ConvertFileToModel(new PasswordCsvConvertor());
        var storage2 = new AddNewTransactionToCsv();
        var service2 = new ProcessTransaction(storage2);
        service2.ProcessTransactionWithPassword(password2, InputPassword2, Money2.Amount);
        Console.Read();
        break;
    case 3:
        //show the recent transactions
        var ListTransaction = new TransactionShow();
        Console.Read();
        break;
    default:
        Console.WriteLine("Your number is out of reach");
        Console.Read();
        break;
}