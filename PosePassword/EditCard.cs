using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PoseLibrary;
using PoseLibrary.Models;

namespace PosePassword
{
    public class EditCard
    {

        public List<CardModel> EditCards(int chosenId,List<CardModel> cards)
        {
            List<CardModel> Cards = cards;
                //inputting new info of the card
            Console.WriteLine($"your current card number is : {Cards[chosenId - 1].CardNumber}\n");
            Console.WriteLine("enter new card number : ");
            string? CardNumb = Console.ReadLine();
            Console.WriteLine($"your current cvv2 number is : {Cards[chosenId - 1].Cvv2}\n");
            Console.WriteLine("enter new cvv2 number : ");
            string? Cvv2Numb = Console.ReadLine();
            Console.WriteLine($"your current card expire month is : {Cards[chosenId - 1].DateMonth}\n");
            Console.WriteLine("enter new month date : ");
            string? MonthNumb = Console.ReadLine();
            Console.WriteLine($"your current card expire year is : {Cards[chosenId - 1].DateYear}\n");
            Console.WriteLine("enter new year date : ");
            string? YearNumb = Console.ReadLine();

             ConvertCardType convertedCardType = new ConvertCardType(
                CardNumb,
                Cvv2Numb,
                MonthNumb,
                YearNumb);

                // validating new info
            Validation.ValidationCartNumber(convertedCardType.CardNumber);
            Validation.ValidationCvv2(convertedCardType.Cvv2);
            Validation.ValidationDateMonth(convertedCardType.DateMonth);
            Validation.ValidationDateYear(convertedCardType.DateYear);

            Cards[chosenId - 1].CardNumber = convertedCardType.CardNumber;
            Cards[chosenId - 1].Cvv2 = convertedCardType.Cvv2;
            Cards[chosenId - 1].DateMonth = convertedCardType.DateMonth;
            Cards[chosenId - 1].DateYear = convertedCardType.DateYear ;

            return Cards;
        }
    }
}