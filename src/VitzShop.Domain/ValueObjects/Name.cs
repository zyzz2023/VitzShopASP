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
        public static Name Create(string name)
        {
            if(string.IsNullOrEmpty(name) || name.Length > 50)
                throw new InvalidNameException(name);

            return new Name(name);
        }
        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
