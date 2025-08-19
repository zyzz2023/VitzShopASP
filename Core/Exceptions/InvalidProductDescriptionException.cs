using Org.BouncyCastle.Bcpg.OpenPgp;

namespace VitzShop.Core.Exceptions
{
    public class InvalidProductDescriptionException : Exception
    {
        public InvalidProductDescriptionException(string value) : base(value) { }
    }
}
