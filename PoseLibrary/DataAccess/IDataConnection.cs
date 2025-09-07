using PoseLibrary.Models;

namespace PoseLibrary.DataAccess
{
    public interface IDataConnection
    {
        CardModel CreateCard(CardModel model);
        TransactionModel Transaction(TransactionModel model);
        PasswordModel CreatePassword(PasswordModel model);
    }
}