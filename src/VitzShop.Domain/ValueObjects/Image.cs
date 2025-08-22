using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VitzShop.Domain.Common;
using VitzShop.Domain.Exceptions;

namespace VitzShop.Domain.ValueObjects
{
    public class Image : ValueObject
    {
        public string ImageUrl { get; }
        public bool IsMain { get; }
        public int DisplayOrder { get; }

        public Image(string imageUrl, bool isMain, int displayOrder)
        {
            ImageUrl = imageUrl;
            IsMain = isMain;
            DisplayOrder = displayOrder;
        }

        public static Image Create(string url, bool isMain = false, int displayOrder = 0)
        {
            if ((!Uri.TryCreate(url, UriKind.Absolute, out _)))
                throw new DomainException("Invalid image URL");
            if (displayOrder < 0)
                throw new DomainException("Invalid DisplayOrder");

            return new Image(url, isMain, displayOrder);
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return new { ImageUrl, IsMain, DisplayOrder};
        }
    }

}
