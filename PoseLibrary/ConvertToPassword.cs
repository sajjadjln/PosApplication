using PoseLibrary.Models;

namespace PoseLibrary
{
    public class ConvertToPassword : PasswordModel
    {
        public ConvertToPassword(string? password, DateTime dateTime)
        {
            Password = password;
            DateTime = dateTime;
        }
    }
}