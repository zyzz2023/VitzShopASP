using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VitzShop.Application.Commands
{
    public class DecreaseProductVariantQuantityCommand
    {
        public Guid VariantId { get; set; }
        public int Amount { get; set; }
    }
}
