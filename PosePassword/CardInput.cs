using PoseLibrary;
using PoseLibrary.Models;

namespace PosePassword
{
    public static class CardInput
    {
        public static CardModel CardInputInfo()
        {
            try
            {
                Console.WriteLine("Please enter your card number: ");
                string? cardNumberInput = Console.ReadLine();

                Console.WriteLine("Please enter your CVV2 number: ");
                string? cvv2Input = Console.ReadLine();

                Console.WriteLine("Please enter your card expire month: ");
                string? dateMonthInput = Console.ReadLine();

                Console.WriteLine("Please enter your card expire year: ");
                string? dateYearInput = Console.ReadLine();

                // Validation happens INSIDE the builder now
                var card = new CardModelBuilder()
                    .WithCardNumber(cardNumberInput)
                    .WithCvv(cvv2Input)
                    .WithDate(dateMonthInput, dateYearInput)
                    .Build();

                return card;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Console.WriteLine("Please try again.\n");
                return CardInputInfo(); // Recursive retry
            }
        }
    }
}