using PoseLibrary;
using PoseLibrary.Models;

namespace PosePassword
{
    public static class CardInput
    {
        public static CardModel CardInputInfo()
        {
            Console.WriteLine("please Enter your card number: ");
            string? CardNumberInput = Console.ReadLine();
            Console.WriteLine("please Enter your Cvv2 number: ");
            string? Cvv2Input = Console.ReadLine();
            Console.WriteLine("please Enter your card expire month date: ");
            string? DateMonthInput = Console.ReadLine();
            Console.WriteLine("please Enter your card expire year date: ");
            string? DateYearInput = Console.ReadLine();

            //converting all the input string types to CardModel types
            var convertedCardType = new CardModelBuilder().WithCardNumber(CardNumberInput).WithCvv(Cvv2Input)
                .WithDate(DateMonthInput, DateYearInput).Build();

            //validating each of the inputs
            Validation.ValidationCartNumber(convertedCardType.CardNumber);
            Validation.ValidationCvv2(convertedCardType.Cvv2);
            Validation.ValidationDateMonth(convertedCardType.DateMonth);
            Validation.ValidationDateYear(convertedCardType.DateYear);
            return convertedCardType;
        }
    }
}