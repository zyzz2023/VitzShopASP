using VitzShop.Domain.Common;
using VitzShop.Domain.Exceptions.InvalidExceptions;

namespace VitzShop.Domain.ValueObjects
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