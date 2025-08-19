using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace VitzShop.Core.Exeptions
{
    public class InvalidProductNameException : Exception
    {
        public InvalidProductNameException(string productName) : base(productName) { }
    }
}
