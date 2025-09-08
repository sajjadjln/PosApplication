namespace PosePassword
{
    public class ShowMassage
    {
        //public Decimal Amount { get; set; }
        public int DynamicPasswordSwitch()
        {
            Console.WriteLine("Welcome to password application");
            Console.WriteLine("please enter the number of your desire option(1 or 2)\n");
            Console.WriteLine(
                "1.Create a new card\n2.choose a saved card and generate password\n3.edit a card information\n4.remove a card");
            int FirstUserInput = 0;

            try
            {
                FirstUserInput = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
            }
            catch (FormatException)
            {
                throw new FormatException("please enter a number");
            }

            return FirstUserInput;
        }

        public int PoseSwitch()
        {
            int FirstUserInput = 0;
            Console.WriteLine("Welcome to Pose application\n\n");
            Console.Clear();
            Console.WriteLine("1.purchasing by using a saved card");
            Console.WriteLine("2.purchasing by entering card information");
            Console.WriteLine("3.Display recent transactions");
            try
            {
                FirstUserInput = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
            }
            catch (FormatException)
            {
                throw new FormatException("please enter a number");
            }

            return FirstUserInput;
        }
    }
}