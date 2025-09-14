using PoseLibrary.DataAccess;
using PoseLibrary.Models;

namespace PosePassword
{
    public class ProcessTransaction
    {
        private readonly IDataConnection<TransactionModel> _transactionStorage;

        public ProcessTransaction(IDataConnection<TransactionModel> transactionStorage)
        {
            _transactionStorage = transactionStorage;
        }

        public string ProcessTransactionWithPassword(List<PasswordModel> password, string? inputPassword,
            decimal amount)
        {
            var result = PasswordValidator.IsTherePasswordInFile(password);
            if (!result.IsValid)
            {
                return result.ErrorMessage;
            }

            var latestPassword = password.OrderByDescending(x => x.Id).Last();
            if (PasswordValidator.ValidatePassword(latestPassword.Password).IsValid &&
                PasswordValidator.CheckPasswordDate(latestPassword.DateTime).IsValid)
            {
                var transactionModel = new TransactionModel(amount, "succeed");
                _transactionStorage.AddModelToFile(transactionModel);
                return "transaction succeed";
            }
            else
            {
                var transactionModel = new TransactionModel(amount, "failed");
                _transactionStorage.AddModelToFile(transactionModel);
                return $"transaction failed";
            }
        }
    }
}