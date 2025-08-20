namespace VitzShop.Domain.Exceptions.InvalidExceptions
{
    public class InvalidProductSizeNameException : Exception
    {
        public InvalidProductSizeNameException(string name) : base(name) { }
    }
}
