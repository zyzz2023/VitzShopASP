using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VitzShop.Domain.Exceptions
{
    internal class InvalidProductSkuException : Exception
    {
        public InvalidProductSkuException(string value) : base(value) { }
    }
}
