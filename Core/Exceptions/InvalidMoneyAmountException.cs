namespace VitzShop.Core.Exeptions
{
    public class InvalidMoneyAmountException : Exception
    {
        public InvalidMoneyAmountException(string money) : base(money) { }
    }
}
