using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VitzShop.Domain.Exceptions.InvalidExceptions;
using VitzShop.Domain.Common;
namespace VitzShop.Domain.ValueObjects
{
    public sealed class ProductSku : ValueObject
    {
        public string Value { get; } = string.Empty;
        private ProductSku(string value)
        {
            Value = value;
        }
        public static ProductSku Create(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(value);
            
            return new ProductSku(value);
        }
        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
