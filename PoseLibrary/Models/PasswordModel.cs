using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoseLibrary.Models
{
    /// <summary>
    /// repersents password id in file and the password itself
    /// </summary>
    public class PasswordModel
    {
        public int Id { get; set; }
        public string? Password { get; set; }
    }
}
