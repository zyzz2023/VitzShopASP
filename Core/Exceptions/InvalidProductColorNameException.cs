using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace VitzShop.Core.Exeptions
{
    public class InvalidProductColorNameException : Exception
    {
        public InvalidProductColorNameException(string colorName) : base(colorName) { }
    }
}
