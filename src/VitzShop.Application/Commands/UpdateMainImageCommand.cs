using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VitzShop.Application.Commands
{
    public class UpdateMainImageCommand
    {
        public Guid ProductId { get; set; }
        public string NewImageUrl { get; set; } = default!;
    }
}
