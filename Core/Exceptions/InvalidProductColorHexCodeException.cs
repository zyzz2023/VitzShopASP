using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace VitzShop.Core.Exeptions
{
    public class InvalidProductColorHexCodeException : Exception
    {
        public InvalidProductColorHexCodeException(string hexCode) : base(hexCode) { }
    }
}
