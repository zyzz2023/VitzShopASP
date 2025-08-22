using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VitzShop.Application.Commands
{
    public class CreateProductCommand
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public decimal Price { get; set; }
        public string MainImageUrl { get; set; } = default!;
        public Guid CategoryId { get; set; }
    }

}
