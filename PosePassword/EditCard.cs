using PoseLibrary;
using PoseLibrary.Models;

namespace PosePassword
{
    public class EditCard
    {
        public List<CardModel> EditCards(int chosenId, List<CardModel> cards)
        {
            List<CardModel> Cards = cards;
            //inputting new info of the card
            Console.WriteLine($"your current card number is : {Cards[chosenId - 1].CardNumber}\n");
            Console.WriteLine("enter new card number : ");
            string? CardNumb = Console.ReadLine();
            Console.Clear();
            Console.WriteLine($"your current cvv2 number is : {Cards[chosenId - 1].Cvv2}\n");
            Console.WriteLine("enter new cvv2 number : ");
            string? Cvv2Numb = Console.ReadLine();
            Console.Clear();
            Console.WriteLine($"your current card expire month is : {Cards[chosenId - 1].DateMonth}\n");
            Console.WriteLine("enter new month date : ");
            string? MonthNumb = Console.ReadLine();
            Console.Clear();
            Console.WriteLine($"your current card expire year is : {Cards[chosenId - 1].DateYear}\n");
            Console.WriteLine("enter new year date : ");
            string? YearNumb = Console.ReadLine();
            Console.Clear();

            var card = new CardModelBuilder()
                .WithCardNumber(CardNumb)
                .WithCvv(Cvv2Numb)
                .WithDate(MonthNumb, YearNumb)
                .Build();

            Cards[chosenId - 1].CardNumber = card.CardNumber;
            Cards[chosenId - 1].Cvv2 = card.Cvv2;
            Cards[chosenId - 1].DateMonth = card.DateMonth;
            Cards[chosenId - 1].DateYear = card.DateYear;

            return Cards;
        }
    }
}