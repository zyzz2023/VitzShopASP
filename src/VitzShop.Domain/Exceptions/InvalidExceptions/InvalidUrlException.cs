using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VitzShop.Domain.Exceptions.InvalidExceptions
{
    internal class InvalidUrlException : Exception
    {
        public InvalidUrlException(string value) : base(value) { }
    }
}
