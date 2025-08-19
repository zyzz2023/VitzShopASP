using Org.BouncyCastle.Utilities.Encoders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using VitzShop.Core.Common;
using VitzShop.Core.Exeptions;

namespace VitzShop.Core.ValueObjects
{
    public sealed class ProductColor : ValueObject
    {
        public string ColorName { get; } = string.Empty;
        public string HexCode { get; } = string.Empty;
        
        private ProductColor(string colorName, string hexCode) 
        {
            ColorName = colorName;
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
            yield return new object[] { ColorName, HexCode };
    }
}
