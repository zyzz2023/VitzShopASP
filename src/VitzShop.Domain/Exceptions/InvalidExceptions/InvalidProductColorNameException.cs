namespace VitzShop.Domain.Exceptions.InvalidExceptions
{
    public class InvalidProductColorNameException : Exception
    {
        public InvalidProductColorNameException(string colorName) : base(colorName) { }
    }
}
