using PoseLibrary;
using PoseLibrary.DataAccess;
using PoseLibrary.DataAccess.TextHelpers;
using PoseLibrary.Models;
using PosePassword;

const string CardFile = "CardModel.csv";
ShowMassage Input = new ShowMassage();
int InputSwitch = Input.DynamicPasswordSwitch();

switch (InputSwitch)
{
    case 1://create new card

       var convertedCardType = CardInput.CardInputInfo();
       TextConnection CardTextFile = new TextConnection();
       CardTextFile.CreateCard(convertedCardType);
        break;

    case 2:// show the list of cards and generate password

        var CardShow = new ShowListCard();
        CardShow.ShowInfo();
        password();
        break;

    case 3: // edit the card info
        var CardShow2 = new ShowListCard();
        CardShow2.ShowInfo();
        if(CardShow2.SaveCardFlag == 1)
        {
            var EditCard = new EditCard();
            var Cards = EditCard.EditCards(CardShow2.CardOption,CardShow2.Cards);
            Cards.SaveToCardFile(CardFile);
        }


        break;
    case 4: // removing a card
        var CardShow3 = new ShowListCard();
        CardShow3.ShowInfo();
        if(CardShow3.SaveCardFlag == 1)
        {
            var removeCard = new RemoveCard();
            var removedCards = removeCard.RemoveCards(CardShow3.CardOption,CardShow3.Cards);
            removedCards.SaveToCardFile(CardFile);
        }
        break;
    default:
        Console.WriteLine("Your number is out of reach");
        break;
}

 void password()
{

     Random generator = new Random();
     String r = generator.Next(100000, 1000000).ToString("D6");
     Console.WriteLine($"this is your password : {r}");
     TextConnection PasswordTextFile = new TextConnection();
     ConvertToPassword password = new ConvertToPassword(r,DateTime.Now);
     PasswordTextFile.CreatePassword(password);

}
