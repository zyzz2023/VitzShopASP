using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VitzShop.Domain.Common;
using VitzShop.Domain.Exceptions.InvalidExceptions;

namespace VitzShop.Domain.ValueObjects
{
    public sealed class Gender : ValueObject
    {
        public string Value { get; }

        public Gender(string gender)
        {
            Value = gender;
        }
        public static Gender Create(string gender)
        {
            if (string.IsNullOrEmpty(gender) || gender.Length > 50)
                throw new InvalidGenderException(gender);

            return new Gender(gender);
        }
        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
