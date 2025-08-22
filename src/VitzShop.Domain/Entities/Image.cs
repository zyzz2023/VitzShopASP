//using System.Reflection.Metadata.Ecma335;
//using VitzShop.Domain.Common;
//using VitzShop.Domain.Exceptions;
//using VitzShop.Domain.ValueObjects;

//namespace VitzShop.Domain.Entities
//{
//    public class Image : BaseEntity<Guid>
//    {
//        public Url ImageUrl { get; private set; }
//        public bool IsMain { get; private set; }
//        public int DisplayOrder {  get; private set; }

//        public int ProductVariantId { get; private set; }
//        public ProductVariant ProductVariant { get; private set; }

//        public int ProductId { get; private set; }
//        public Product Product { get; private set; }

//        public static Image Create(
//            string imageUrl,
//            bool isMain = false,
//            int displayOrder = 0)
//        {
//            if ((!Uri.TryCreate(imageUrl, UriKind.Absolute, out _)))
//                throw new DomainException("Invalid image URL");
//            if (displayOrder < 0)
//                throw new DomainException("Invalid DisplayOrder");
           
//            return new Image
//            {
//                ImageUrl = Url.Create(imageUrl),
//                IsMain = isMain,
//                DisplayOrder = displayOrder
//            };
//        }
//        public void SetMain(bool isMain) => IsMain = isMain;
//        public void UpdateDisplayOrder(int order) => DisplayOrder = order;
//        public string GetUrl()
//        { 
//            return ImageUrl.Value;
//        }
//    }
//}
