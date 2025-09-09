namespace PoseLibrary.Models
{
    public class PasswordModel(string? password, DateTime date)
    {
        public int Id { get; set; }
        public string? Password { get; set; } = password;
        public DateTime DateTime { get; set; } = date;
    }
}