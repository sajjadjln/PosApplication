using PoseLibrary;
using PoseLibrary.Models;

namespace PosePassword;

public static class PasswordValidator
{
    public static ValidationResult CheckPasswordDate(DateTime date)
    {
        if (DateTime.Compare(date.AddMinutes(5), DateTime.Now) > 0)
            return ValidationResult.Failure("Password is expired");
        return ValidationResult.Success();
    }
    
    public static ValidationResult ValidatePassword(string? password)
    {
        if (password == null)
            return ValidationResult.Failure("Password cannot be empty");
        if (password.Length < 6)
            return ValidationResult.Failure("Password must be 6 digits");
        if (!password.All(char.IsDigit))
            return ValidationResult.Failure("wrong password!");
        return ValidationResult.Success();
    }

    public static ValidationResult IsTherePasswordInFile(List<PasswordModel> passwords)
    {
        if (passwords.Count == 0)
        {
            return ValidationResult.Failure("No passwords in the file, please use Password generator");
        }
        return ValidationResult.Success();
    }
}

