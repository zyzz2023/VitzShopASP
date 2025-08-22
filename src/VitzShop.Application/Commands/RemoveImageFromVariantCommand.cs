using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VitzShop.Application.Commands
{
    public class RemoveImageFromVariantCommand
    {
        public Guid VariantId { get; set; }
        public string ImageUrl { get; set; } = default!;
    }

}
