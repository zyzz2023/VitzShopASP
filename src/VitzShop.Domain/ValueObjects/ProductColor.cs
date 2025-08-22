
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using VitzShop.Domain.Exceptions.InvalidExceptions;
using VitzShop.Domain.Common;

namespace VitzShop.Domain.ValueObjects
{
    public sealed class ProductColor : ValueObject
    {
        public string Value { get; } = string.Empty;
        public string HexCode { get; } = string.Empty;
        
        private ProductColor(string colorName, string hexCode) 
        {
            Value = colorName;
            HexCode = hexCode;
        }
        public static ProductColor Create(string colorName, string hexCode)
        {
            if(string.IsNullOrEmpty(colorName) || colorName.Length > 100)
                throw new InvalidProductColorNameException(colorName);
            if(string.IsNullOrEmpty(hexCode) || !IsValidColorHexCode(hexCode))
                throw new InvalidProductColorHexCodeException(hexCode);

            return new ProductColor(colorName, hexCode);
        }
        public static bool IsValidColorHexCode(string hexCode) => Regex.IsMatch(hexCode, "^#([A-Fa-f0-9]{6}|[A-Fa-f0-9]{3})$");
        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return new object[] { Value, HexCode };
        }
    }
}
