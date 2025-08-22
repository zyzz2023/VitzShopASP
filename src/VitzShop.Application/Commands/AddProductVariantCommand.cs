using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VitzShop.Application.Commands
{
    public class AddProductVariantCommand
    {
        public Guid ProductId { get; set; }
        public string Color { get; set; } = default!;
        public string Size { get; set; } = default!;
        public int Quantity { get; set; }
    }

}
