namespace PoseLibrary;

public static class CardValidator
{
    public static ValidationResult ValidateCardNumber(string? cardNumber)
    {
        if (string.IsNullOrWhiteSpace(cardNumber))
            return ValidationResult.Failure("Card number cannot be empty");

        var cleaned = new string(cardNumber.Where(char.IsDigit).ToArray());

        if (cleaned.Length < 13 || cleaned.Length > 19)
            return ValidationResult.Failure("Card number must be between 13-19 digits");

        return ValidationResult.Success();
    }

    public static ValidationResult ValidateCvv(int cvv)
    {
        if (cvv <= 0)
            return ValidationResult.Failure("CVV must be positive");

        var cvvStr = cvv.ToString();
        if (cvvStr.Length < 3 || cvvStr.Length > 4)
            return ValidationResult.Failure("CVV must be 3 or 4 digits");

        return ValidationResult.Success();
    }

    public static ValidationResult ValidateExpiryDate(int month, int year)
    {
        if (month < 1 || month > 12)
            return ValidationResult.Failure("Month must be between 1-12");

        var fullYear = year < 50 ? 2000 + year : 1900 + year;
        var expiryDate = new DateTime(fullYear, month, DateTime.DaysInMonth(fullYear, month));

        if (expiryDate < DateTime.Now)
            return ValidationResult.Failure("Card has expired");

        return ValidationResult.Success();
    }

    public static ValidationResult ValidatePassword(string? password)
    {
        if (password == null)
            return ValidationResult.Failure("Password cannot be empty");
        if (password.Length < 6)
            return ValidationResult.Failure("Password must be 6 digits");
        if (!password.All(Char.IsDigit))
            return ValidationResult.Failure("wrong password!");

        return ValidationResult.Success();
    }
}

public record ValidationResult(bool IsValid, string? ErrorMessage = null)
{
    public static ValidationResult Success() => new(true);
    public static ValidationResult Failure(string message) => new(false, message);
}