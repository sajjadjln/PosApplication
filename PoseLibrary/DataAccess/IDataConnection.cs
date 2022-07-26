using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoseLibrary.DataAccess
{
    public interface IDataConnection
    {
        Models.CardModel CreateCard(Models.CardModel model);
        Models.TransactionModel Transaction(Models.TransactionModel model);
        Models.PasswordModel CreatePassword(Models.PasswordModel model);

    }
}
