namespace VitzShop.Domain.Exceptions.InvalidExceptions
{
    public class InvalidNameException : Exception
    {
        public InvalidNameException(string productName) : base(productName) { }
    }
}
