namespace PoseLibrary
{
    public class Validation
    {
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
                    throw new ArgumentException("wrong cart number!");
                }
            }
        }
        public static void ValidationCvv2(int cvv2)
        {
            double Cvv2Count = Math.Floor(Math.Log10(cvv2) + 1);
            if (Cvv2Count < 3 || Cvv2Count > 4)
            {
                throw new ArgumentException("your Cvv2 number should be 3 or 4 digits");
            }

        }
        public static void ValidationDateMonth(int dateMonth)
        {
            double DateCount = Math.Floor(Math.Log10(dateMonth) + 1); // getting the count of the number
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
        public static void ValidationPassword(string? password)
        {
            if (password == null)
            {
                throw new ArgumentNullException(nameof(password));
            }
            if (password.Length != 6)
            {
                throw new ArgumentException("your password should be 6 digits");
            }
            foreach (var i in password)
            {
                bool a = Char.IsDigit(i);
                if (a == false)
                {
                    throw new ArgumentException("wrong password!");
                }
            }
        }
    }
}
