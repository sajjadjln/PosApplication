using PoseLibrary;
using PoseLibrary.DataAccess;
using PoseLibrary.DataAccess.TextHelpers;
using PoseLibrary.Models;
using PosePassword;

const string CardFile = "CardModel.csv";
Console.WriteLine("Welcome to password application");
Console.WriteLine("please enter the number of your desire option(1 or 2)\n");
Console.WriteLine("1.Create a new card\n2.choose a saved card and generate password\n3.edit a card information\n4.remove a card");
int FirstUserInput = 0;

try
{
     FirstUserInput = Convert.ToInt32(Console.ReadLine());
     Console.Clear();
}
catch (FormatException)
{
    Console.Write("wrong number!");
}

switch (FirstUserInput)
{
    case 1://create new card

       var convertedCardType = CardInput.CardInputInfo();
       TextConnection CardTextFile = new TextConnection();
        CardTextFile.CreateCard(convertedCardType);
        break;

    case 2:// show the list of cards
           // how to access field CardFile in TextConnection class

        var CardShow = new ShowListCard();
        CardShow.ShowInfo();
        password();
        break;

    case 3: // edit the card info
        var CardShow2 = new ShowListCard();
        CardShow2.ShowInfo();
        var EditCard = new EditCard();
        var Cards = EditCard.EditCards(CardShow2.CardOption,CardShow2.Cards);
        Cards.SaveToCardFile(CardFile);

        break;
    case 4:
        var CardShow3 = new ShowListCard();
        CardShow3.ShowInfo();
        var removeCard = new RemoveCard();
        var removedCards = removeCard.RemoveCards(CardShow3.CardOption,CardShow3.Cards);
        removedCards.SaveToCardFile(CardFile);
        break;
    default:
        Console.WriteLine("Your number is out of reach");
        break;
}

 void password()
{

     Random generator = new Random();
     String r = generator.Next(0, 1000000).ToString("D6");
     Console.WriteLine($"this is your password : {r}");
     TextConnection PasswordTextFile = new TextConnection();
     ConvertToPassword password = new ConvertToPassword(r);
     PasswordTextFile.CreatePassword(password);

}
