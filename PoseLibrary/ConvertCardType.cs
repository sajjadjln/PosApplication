using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoseLibrary
{
    public class ConvertCardType : Models.CardModel
    {
        /// <summary>
        ///  this Constructor takes input strings and convert them to their correct type
        /// </summary>
        public ConvertCardType(string? cardNumber, string? cvv2, string? dateMonth, string? dateYear)
        {
            CardNumber = cardNumber;
            
            
            int Cvv2NumberValue = int.TryParse(cvv2, out Cvv2NumberValue) ? Cvv2NumberValue : 0;
            //int.TryParse(cvv2, out int Cvv2NumberValue);
            Cvv2 = Cvv2NumberValue;

            int DateMonthNumberValue = int.TryParse(dateMonth, out DateMonthNumberValue) ? DateMonthNumberValue : 0;
            DateMonth = DateMonthNumberValue;

            int DateYearNumberValue = int.TryParse(dateYear, out DateYearNumberValue) ? DateYearNumberValue : 0;
            DateYear = DateYearNumberValue;
            if (Cvv2 == 0 || DateMonth == 0 || DateYear == 0 || CardNumber == null)
            {
                throw new Exception("an error occured check your entry numbers and try again");
            }
        }
    }
}
