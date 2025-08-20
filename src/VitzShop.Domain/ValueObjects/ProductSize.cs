using VitzShop.Domain.Exceptions.InvalidExceptions;
using VitzShop.Domain.Common;

namespace VitzShop.Domain.ValueObjects
{
    public sealed class ProductSize : ValueObject
    {
        public string Value { get; } = string.Empty;
        private ProductSize(string name) => Value = name;
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
