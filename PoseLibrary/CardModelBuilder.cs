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
        _cardNumber = cardNumber ?? throw new ArgumentNullException(nameof(cardNumber));
        return this;
    }

    public CardModelBuilder WithCvv(string cvv)
    {
        if (!int.TryParse(cvv, out var cvvValue))
            throw new ArgumentException("Invalid CVV format");
        _cvv2 = cvvValue;
        return this;
    }

    public CardModelBuilder WithDate(string dateMonth, string dateYear)
    {
        if (!int.TryParse(dateMonth, out var dateMonthValue))
            throw new ArgumentException("Invalid date month format");
        if (!int.TryParse(dateYear, out var dateYearValue))
            throw new ArgumentException("Invalid date year format");
        _dateMonth = dateMonthValue;
        _dateYear = dateYearValue;
        return this;
    }

    public CardModel Build()
    {
        //       ValidateCard(_card);
        return new CardModel
        {
            CardNumber = _cardNumber,
            Cvv2 = _cvv2,
            DateMonth = _dateMonth,
            DateYear = _dateYear
        };
    }
}