using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VitzShop.Domain.Exceptions.InvalidExceptions;
using VitzShop.Domain.Common;

namespace VitzShop.Domain.ValueObjects
{
    public class ProductQuantity : ValueObject
    {
        public int Quantity { get; }
        private ProductQuantity(int quantity) 
        {
            Quantity = quantity;
        }
        public static ProductQuantity Create(int quantity)
        {
            if (quantity < 0)
                throw new InvalidProductQuantityException(quantity.ToString());

            return new ProductQuantity(quantity);
        }
        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Quantity;
        }
    }
}
