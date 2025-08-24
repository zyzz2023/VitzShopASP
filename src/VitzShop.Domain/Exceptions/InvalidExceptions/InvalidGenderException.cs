using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VitzShop.Domain.Exceptions.InvalidExceptions
{
    public class InvalidGenderException : Exception
    {
        public InvalidGenderException(string gender) : base(gender) { }
    }
}
