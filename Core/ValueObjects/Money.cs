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
    public class Money : ValueObject
    {
        public decimal Amount { get; }
        private Money(decimal amount) => Amount = amount;
        public static Money Create(decimal amount)
        {
            if (amount < 0)
                throw new InvalidMoneyAmountException(amount.ToString());

            return new Money(amount);
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Amount;
        }
    }
}