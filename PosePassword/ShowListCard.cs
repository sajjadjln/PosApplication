using PoseLibrary.DataAccess;
using PoseLibrary.DataAccess.TextHelpers;
using PoseLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosePassword
{

    public class ShowListCard : TextConnection
    {
        public int SaveCardFlag { get; set; } = 1;
        public int CardOption { get; set; }
        public List<CardModel> Cards { get; set; } = new List<CardModel>();
        public void ShowInfo()
        {
            List<CardModel> Card = CardFile.FullFilePath().LoadFile().ConvertToCardModel();
            if(Card.Count == 0)
            {
                Console.WriteLine("there is no saved card");
                SaveCardFlag = 0;
            }
            else
            {
            Cards = Card;
            int CardOption = 0;
            for (int i = 0; i < Cards.Count; i++)
            {

                Console.WriteLine($"Id of card: {Cards[i].Id} | " +
                    $"your card number : {Cards[i].CardNumber} | " +
                    $"your Cvv2 number : {Cards[i].Cvv2} | " +
                    $"your card expire date: {Cards[i].DateYear}/{Cards[i].DateMonth}");
            }
            Console.WriteLine("\nchoose your desire card by entering the Id");
            try
            {
                CardOption = Convert.ToInt32(Console.ReadLine());
                this.CardOption = CardOption;
                Console.Clear();
            }
            catch (FormatException)
            {
                Console.Write("Input string is not a digit.");
            }
            }
        }
    }
}
