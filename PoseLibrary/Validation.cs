namespace PoseLibrary
{
    public class Validation
    {
        /// <summary>
        /// this method validates the cart number 
        /// </summary>
        /// <param name="CartNumber">string of numbers</param>
        /// <exception cref="ArgumentException">if cart number wasnt the 16 digits 
        /// and if any digit wasnt numeric
        /// </exception>
        public static void ValidationCartNumber(string? cardNumber)
        {
            if (cardNumber == null)
            {
                throw new ArgumentNullException(nameof(cardNumber));
            }
            if (cardNumber.Length != 16)
            {
                throw new ArgumentException("your cart number should be 16 digits");
            }
            foreach (var i in cardNumber)
            {
                bool a = Char.IsDigit(i);
                if (a == false)
                {
                    throw new ArgumentException("wrong cart number\n please enter right number");
                }
            }
        }
        /// <summary>
        /// this method validates Cvv2
        /// </summary>
        /// <param name="cvv2">3 or 4 digit number</param>
        /// <exception cref="ArgumentException">if the lenght of number wasnt right </exception>
        public static void ValidationCvv2(int cvv2)
        {
            double Cvv2Count = Math.Floor(Math.Log10(cvv2) + 1);
            if (Cvv2Count < 3 || Cvv2Count > 4)
            {
                throw new ArgumentException("your Cvv2 number should be 3 or 4 digits");
            }

        }
        /// <summary>
        /// this method validates DateMonth and DateYear
        /// </summary>
        /// <exception cref="ArgumentException">if the lenght of number wasnt right</exception>
        public static void ValidationDateMonth(int dateMonth)
        {
            double DateCount = Math.Floor(Math.Log10(dateMonth) + 1);
            if (DateCount < 1 || DateCount > 2 || dateMonth > 12 || dateMonth < 1)
            {
                throw new ArgumentException("wrong Date");
            }
        }
        public static void ValidationDateYear(int dateYear)
        {
            double DateCount = Math.Floor(Math.Log10(dateYear) + 1);
            if (DateCount < 1 || DateCount > 2 || dateYear > 6 )
            {
                throw new ArgumentException("wrong Date");
            }
        }
        
        public static void ValidationPassword(int password)
        {
            double PasswordCount = Math.Floor(Math.Log10(password) + 1);

            if (PasswordCount < 6 && PasswordCount > 6)
            {
                throw new ArgumentException("your password number should be 6 digits");
            }
        }
    }
}
