using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoseLibrary
{
    public class ConvertToPassword : Models.PasswordModel
    {
        public ConvertToPassword(string? password,DateTime dateTime)
        {
            Password = password;
            DateTime = dateTime;
        }
    }
}
