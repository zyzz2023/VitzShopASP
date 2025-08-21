using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VitzShop.Domain.Exceptions.InvalidExceptions;
using VitzShop.Domain.Common;

namespace VitzShop.Domain.ValueObjects
{
    public sealed class Name : ValueObject
    {
        public string Value { get; }

        private Name(string name)
        {
            Value = name;
        }
        public static Name Create(string productName)
        {
            if(string.IsNullOrEmpty(productName) || productName.Length > 50)
                throw new InvalidProductNameException(productName);

            return new Name(productName);
        }
        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
