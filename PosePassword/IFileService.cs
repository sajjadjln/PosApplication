using PoseLibrary.Models;

namespace PosePassword;

public interface IFileService
{
    Task SaveTransactionAsync(TransactionModel transaction);
    Task SaveCardAsync(CardModel card);
}