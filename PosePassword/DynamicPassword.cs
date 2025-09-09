using PoseLibrary;
using PoseLibrary.DataAccess;
using PoseLibrary.DataAccess.CsvHandling.AddModelToCsv;
using PoseLibrary.DataAccess.CsvHandling.CsvConvertor;
using PosePassword;

const string CardFile = "CardModel.csv";
ShowMassage Input = new ShowMassage();
int InputSwitch = Input.DynamicPasswordSwitch();

switch (InputSwitch)
{
    case 1: //create new card

        var convertedCardType = CardInput.CardInputInfo();
        AddNewCardModelToCsv CardTextFile = new AddNewCardModelToCsv();
        CardTextFile.AddModel(convertedCardType);
        Console.Read();
        break;

    case 2: // show the list of cards and generate password

        var CardShow = new ShowListCard();
        CardShow.ShowInfo();
        password();
        Console.Read();
        break;

    case 3: // edit the card info
        var CardShow2 = new ShowListCard();
        CardShow2.ShowInfo();
        if (CardShow2.SaveCardFlag == 1)
        {
            var EditCard = new EditCard();
            var Cards = EditCard.EditCards(CardShow2.CardOption, CardShow2.Cards);
            Cards.SaveToFile(new CardCsvConvertor(), CardFile); // what this new do here
        }

        Console.Read();

        break;
    case 4: // removing a card
        var CardShow3 = new ShowListCard();
        CardShow3.ShowInfo();
        if (CardShow3.SaveCardFlag == 1)
        {
            var removeCard = new RemoveCard();
            var removedCards = removeCard.RemoveCards(CardShow3.CardOption, CardShow3.Cards);
            removedCards.SaveToFile(new CardCsvConvertor(), CardFile);
        }

        Console.Read();
        break;
    default:
        Console.WriteLine("Your number is out of reach");
        Console.Read();
        break;
}

void password()
{
    Random generator = new Random();
    String r = generator.Next(100000, 1000000).ToString("D6");
    Console.WriteLine($"this is your password : {r}");
    var passwordTextFile = new AddNewPasswordToCsv();
    ConvertToPassword password = new ConvertToPassword(r, DateTime.Now);
    passwordTextFile.AddModel(password);
}