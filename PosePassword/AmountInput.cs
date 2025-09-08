namespace PosePassword
{
    public class AmountInput
    {
        public Decimal Amount { get; set; }
        public AmountInput()
        {
            Console.WriteLine("please Enter your desired amount");
            var InputString = Console.ReadLine();
            decimal Amount;
            decimal.TryParse(InputString, out Amount);
            this.Amount = Amount;
        }
    }
}