using Infrastructure.Entities.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Eshop
{
    public class Product : BaseEntity
    {

        private int _price = 0;
        private int? _oldPrice = null;
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public bool IsActive { get; set; }
        public string ImageGallery { get; set; }
        public string Image { get; set; }
        public string specifications { get; set; }
        public string ExpertReview { get; set; }
        public string Overview { get; set; }
        public int Order { get; set; } = 0;
        public int Inventory { get; set; } = 0;
        public decimal Rate { get; set; } = 0;
        public int ParentCategoryId { get; set; }
        public int? BrandId { get; set; }
        #region Seo
        public string SeoTitle { get; set; }
        public string SeoUrl { get; set; }
        public string SeoDescription { get; set; }
        public string SeoKeyword { get; set; }
        public string SeoImage { get; set; }
        #endregion
        public int Price 
        { 
            get 
            {
                return GetPrice();
            }
            set 
            {
                Price = _price;
            } 
        }
        public int? OldPrice
        {
            get
            {
                return _oldPrice;
            }
            set
            {
                OldPrice = _oldPrice;
            }
        }
        public int? PercentDiscount { get; set; } = 0;
        [ForeignKey(nameof(BrandId))]
        public Brand Brand { set; get; }
        [ForeignKey(nameof(ParentCategoryId))]
        public ProductCategory Category { set; get; }
        //public ICollection<ProductFeatures> ProductFeatures { get; set; }
        public ICollection<Discount> Discount { set; get; }
        private int GetPrice()
        {
            var dis = GetPreferredDiscount(Discount, _price);
            if (dis != null)
            {
                var discountAmount = dis.GetDiscountAmount(_price);
                int newPrice = _price - discountAmount;
                _oldPrice = _price;
                PercentDiscount = (discountAmount * 100) / _price;
                return newPrice;
            }
            return _price;
        }
        private Discount GetPreferredDiscount(ICollection<Discount> discounts, int price)
        {
            Discount preferredDiscount = null;
            decimal? maximumDiscountValue = null;
            if (discounts != null)
            {
                foreach (var discount in discounts)
                {
                    var currentDiscountValue = discount.GetDiscountAmount(price);
                    if (currentDiscountValue != decimal.Zero)
                    {
                        if (!maximumDiscountValue.HasValue || currentDiscountValue > maximumDiscountValue)
                        {
                            maximumDiscountValue = currentDiscountValue;
                            preferredDiscount = discount;
                        }
                    }
                }
            }
         return preferredDiscount;
        }
    }
}
