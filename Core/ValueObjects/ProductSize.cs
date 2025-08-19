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
    public sealed class ProductSize : ValueObject
    {
        public string Value { get; } = string.Empty;
        private ProductSize(string name)
        {
            Value = name;
        }
        public static ProductSize Create(string name)
        {
            if(string.IsNullOrEmpty(name) || name.Length > 15)
                throw new InvalidProductSizeNameException(name);

            return new ProductSize(name);
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
