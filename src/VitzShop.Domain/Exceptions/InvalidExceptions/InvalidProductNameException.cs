namespace VitzShop.Domain.Exceptions.InvalidExceptions
{
    public class InvalidProductNameException : Exception
    {
        public InvalidProductNameException(string productName) : base(productName) { }
    }
}
