using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoseLibrary.Models
{
    /// <summary>
    /// Repersents transaction of every attempt by the amount of it 
    /// and if it was succesfull or not by the state
    /// </summary>
    public class TransactionModel
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string? State { get; set; }
    }
}
