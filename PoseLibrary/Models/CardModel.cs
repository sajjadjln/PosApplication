namespace PoseLibrary.Models
{
    public class CardModel
    {
        public int Id { get; set; }
        public string? CardNumber { get; set; }
        public int Cvv2 { get; set; }
        public int DateMonth { get; set; }
        public int DateYear { get; set; }
    }
}