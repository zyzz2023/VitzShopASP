using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VitzShop.Domain.Exceptions.InvalidExceptions
{
    internal class InvalidProductQuantityException : Exception
    {
        public InvalidProductQuantityException(string quantity) : base(quantity) { }
    }
}
