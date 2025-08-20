namespace VitzShop.Domain.Exceptions.InvalidExceptions
{
    public class InvalidMoneyAmountException : Exception
    {
        public InvalidMoneyAmountException(string money) : base(money) { }
    }
}
