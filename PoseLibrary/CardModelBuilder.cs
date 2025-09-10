using PoseLibrary.Models;

namespace PoseLibrary;

public class CardModelBuilder
{
    private string? _cardNumber;
    private int _cvv2;
    private int _dateMonth;
    private int _dateYear;

    public CardModelBuilder WithCardNumber(string cardNumber)
    {
        var result = CardValidator.ValidateCardNumber(cardNumber);
        if (!result.IsValid)
            throw new ArgumentException(result.ErrorMessage);
        _cardNumber = cardNumber;
        return this;
    }

    public CardModelBuilder WithCvv(string cvv)
    {
        if (!int.TryParse(cvv, out var cvvValue))
            throw new ArgumentException("Invalid CVV format");
        
        var result = CardValidator.ValidateCvv(cvvValue);
        if (!result.IsValid)
            throw new ArgumentException(result.ErrorMessage);
            
        _cvv2 = cvvValue;
        return this;
    }

    public CardModelBuilder WithDate(string dateMonth, string dateYear)
    {
        if (!int.TryParse(dateMonth, out var monthValue) || 
            !int.TryParse(dateYear, out var yearValue))
            throw new ArgumentException("Date values must be numeric");
            
        var result = CardValidator.ValidateExpiryDate(monthValue, yearValue);
        if (!result.IsValid)
            throw new ArgumentException(result.ErrorMessage);
            
        _dateMonth = monthValue;
        _dateYear = yearValue;
        return this;

    }

    public CardModel Build()
    {
        return new CardModel
        {
            CardNumber = _cardNumber,
            Cvv2 = _cvv2,
            DateMonth = _dateMonth,
            DateYear = _dateYear
        };
    }
}