namespace VitzShop.Core.Exeptions
{
    public class InvalidProductSizeNameException : Exception
    {
        public InvalidProductSizeNameException(string name) : base(name) { }
    }
}
