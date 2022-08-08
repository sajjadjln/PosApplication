using PoseLibrary;
using PoseLibrary.DataAccess;
using PoseLibrary.DataAccess.TextHelpers;
using PoseLibrary.Models;
using PosePassword;


const string CardFile = "CardModel.csv";
const string PasswordFile = "Password.csv";

ShowMassage Input = new ShowMassage();
int InputSwitch = Input.PoseSwitch();

switch (InputSwitch)
{
    case 1://use a save card
        var Money1 = new AmountInput();
        var cardShow = new ShowListCard();
        cardShow.ShowInfo();
        List<CardModel> Cards = CardFile.FullFilePath().LoadFile().ConvertToCardModel();
        foreach (var Card in Cards)
        {
            if (Card.Id == cardShow.CardOption)
            {
                Console.WriteLine("Enter your password");
                string? InputPassword = Console.ReadLine();
                Validation.ValidationPassword(InputPassword);
                List<PasswordModel> Password = PasswordFile.FullFilePath().
                    LoadFile().ConvertToPasswordModel();
                TransactionProcess TransactionResult = new TransactionProcess(
                    Password, InputPassword,Money1.Amount);
            }
        }
        Console.Read();
            break;
    case 2:// entering info

        Console.Clear();
        var Money2 = new AmountInput();
        var convertedCardType = CardInput.CardInputInfo();
        Console.WriteLine("Enter your password");
        string? InputPassword2 = Console.ReadLine();
        Validation.ValidationPassword(InputPassword2);
        List<PasswordModel> Password2 = PasswordFile.FullFilePath().
                    LoadFile().ConvertToPasswordModel();

        TransactionProcess TransactionResult2 = new TransactionProcess(
            Password2, InputPassword2, Money2.Amount);
            //check to see if transaction succeed then ask for saving card info
        if (TransactionResult2.FlagSaveInfo == 1)
        {
            TransactionProcess SaveInformation = new TransactionProcess(convertedCardType);
        }
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