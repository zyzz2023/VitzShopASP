using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VitzShop.Application.DTOs
{
    public class ProductVariantDto
    {
        public Guid Id { get; set; }
        public string ColorName { get; set; } = default!;
        public string ColorHexValue { get; set; } = default!;
        public string Size { get; set; } = default!;
        public int Quantity { get; set; }
        public string Sku { get; set; } = default!;
        public string MainImageUrl { get; set; } = default!;
    }

}
