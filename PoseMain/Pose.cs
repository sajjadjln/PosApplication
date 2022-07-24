using PoseLibrary;
using PoseLibrary.DataAccess;
using PoseLibrary.DataAccess.TextHelpers;
using PoseLibrary.Models;
using PosePassword;

int FirstUserInput = 0;
int SaveInfo = 0;
const string CardFile = "CardModel.csv";
const string PasswordFile = "Password.csv";

Console.WriteLine("Welcome to Pose application\n\n");
Console.WriteLine("please Enter your desired amount");
var InputString = Console.ReadLine();
decimal Amount;
decimal.TryParse(InputString, out Amount);
Console.Clear();
Console.WriteLine("1.using a saved card");
Console.WriteLine("2.entering card information");
try
{
    FirstUserInput = Convert.ToInt32(Console.ReadLine());
    Console.Clear();
}catch (FormatException)
{
    Console.Write("wrong number!");
}
switch (FirstUserInput)
{
    case 1://use a save card
        
        var Cardshow = new ShowListCard();
        Cardshow.ShowInfo();
        List<CardModel> Cards = CardFile.FullFilePath().LoadFile().ConvertToCardModel();
        foreach (var Card in Cards)
        {
            if (Card.Id == Cardshow.CardOption)
            {
                //validating each of the inputs
                Validation.ValidationCartNumber(Card.CardNumber);
                Validation.ValidationCvv2(Card.Cvv2);
                Validation.ValidationDateMonth(Card.DateMonth);
                Validation.ValidationDateYear(Card.DateYear);

                Console.WriteLine("Enter your password");
                string? InputPassword = Console.ReadLine();
                List<PasswordModel> Password = PasswordFile.FullFilePath().
                    LoadFile().ConvertToPasswordModel();
                TransactionProccess TransactionResult = new TransactionProccess(
                    Password, InputPassword,Amount);
            }
        }
            break;
    case 2:// entering info

        Console.Clear();
        var convertedCardType = CardInput.CardInputInfo();
        //validating each of the inputs
        Validation.ValidationCartNumber(convertedCardType.CardNumber);
        Validation.ValidationCvv2(convertedCardType.Cvv2);
        Validation.ValidationDateMonth(convertedCardType.DateMonth);
        Validation.ValidationDateYear(convertedCardType.DateYear);

        Console.WriteLine("Enter your password");
        string? InputPassword2 = Console.ReadLine();
        List<PasswordModel> Password2 = PasswordFile.FullFilePath().
                    LoadFile().ConvertToPasswordModel();
        SaveInfo=1;
        TransactionProccess TransactionResult2 = new TransactionProccess(
            Password2, InputPassword2, Amount);
        TransactionProccess SaveInformation = new TransactionProccess(convertedCardType, SaveInfo);
        
        break;
    default:
        Console.WriteLine("Your number is out of reach");
        break;
}