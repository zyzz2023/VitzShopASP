namespace VitzShop.Domain.Exceptions.InvalidExceptions
{
    public class InvalidProductDescriptionException : Exception
    {
        public InvalidProductDescriptionException(string value) : base(value) { }
    }
}
