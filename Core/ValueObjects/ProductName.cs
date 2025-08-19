using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VitzShop.Core.Common;
using VitzShop.Core.Exeptions;

namespace VitzShop.Core.ValueObjects
{
    public sealed class ProductName : ValueObject
    {
        public string Value {  get; }

        private ProductName(string name)
        {
            Value = name;
        }
        public static ProductName Create(string productName)
        {
            if(string.IsNullOrEmpty(productName) || productName.Length > 50)
                throw new InvalidProductNameException(productName);

            return new ProductName(productName);
        }
        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
