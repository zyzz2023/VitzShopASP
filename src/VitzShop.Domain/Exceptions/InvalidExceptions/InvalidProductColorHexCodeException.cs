namespace VitzShop.Domain.Exceptions.InvalidExceptions
{
    public class InvalidProductColorHexCodeException : Exception
    {
        public InvalidProductColorHexCodeException(string hexCode) : base(hexCode) { }
    }
}
