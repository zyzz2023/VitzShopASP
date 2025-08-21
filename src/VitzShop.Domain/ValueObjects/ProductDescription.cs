using VitzShop.Domain.Exceptions.InvalidExceptions;
using VitzShop.Domain.Common;

namespace VitzShop.Domain.ValueObjects
{
    public sealed class ProductDescription : ValueObject
    {
        public string Value { get; } = string.Empty;

        public ProductDescription(string value) 
        {
            Value = value;
        }
        public static ProductDescription Create(string value)
        {
            if(string.IsNullOrEmpty(value) || value.Length > 150)
                throw new InvalidProductDescriptionException(value);

            return new ProductDescription(value);
        }
        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;    
        }
    }
}
