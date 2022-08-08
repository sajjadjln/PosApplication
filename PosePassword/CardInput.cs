using PoseLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosePassword
{
    public static class CardInput
    {
        public static ConvertCardType CardInputInfo()
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
            ConvertCardType convertedCardType = new ConvertCardType(
                CardNumberInput,
                Cvv2Input,
                DateMonthInput,
                DateYearInput);

            //validating each of the inputs
            Validation.ValidationCartNumber(convertedCardType.CardNumber);
            Validation.ValidationCvv2(convertedCardType.Cvv2);
            Validation.ValidationDateMonth(convertedCardType.DateMonth);
            Validation.ValidationDateYear(convertedCardType.DateYear);
            return convertedCardType;
        }
    }
}
