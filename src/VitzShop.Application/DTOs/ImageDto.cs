using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VitzShop.Application.DTOs
{
    public class ImageDto
    {
        public string ImageUrl { get; set; }
        public bool IsMain { get; set; }
        public int DisplayOrder { get; set; }
    }
}
