using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoseLibrary
{
    public class ConvertToTransaction : Models.TransactionModel
    {
        public ConvertToTransaction(decimal amount,string state) 
        {
            Amount = amount;
            State = state;
        }
    }
}
