using VitzShop.Domain.Exceptions.InvalidExceptions;
using VitzShop.Domain.Common;

namespace VitzShop.Domain.ValueObjects
{
    public sealed class Url : ValueObject
    {
        public string Value { get; }

        private Url(string value) => Value = value;
        public static Url Create(string value)
        {
            if(string.IsNullOrEmpty(value))
                throw new InvalidUrlException(value);

            return new Url(value);
        }
        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
        public override string ToString()
        {
            return Value;
        }
    }
}
