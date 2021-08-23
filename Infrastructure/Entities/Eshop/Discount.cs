using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Eshop
{
   public class Discount:BaseEntity
    {
        public string Title { get; set; }
        public bool UsePercentage { get; set; }//true is percemt
        public int DiscountPercentage { get; set; }
        public int DisscountAmmount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool RequiredCoponeCode { get; set; }
        public string CoponCode { get; set; }
        public int DiscountTypeId { get; set; }
        public int LimitationTime { get; set; }
        public int DiscountLimitationId { get; set; }

        [NotMapped]
        public DiscountType DiscountType
        {
            get => (DiscountType)this.DiscountTypeId;
            set => this.DiscountTypeId = (int)value;
        }
        public ICollection<Product> Product { set; get; }
        public int GetDiscountAmount(int amount)
        {
            var result = 0;
            if (UsePercentage)
            {
                result = (((amount) * (DiscountPercentage)) / 100);
            }
            else
            {
                result = DisscountAmmount;
            }
            return result;
        }
    }
    public enum DiscountType
    {
        [Display(Name = "تخفیف برای محصولات")]
        Product =1,
        [Display(Name = "تخفیف برای همه")]
        AllProduct = 2,
        [Display(Name = "تخفیف برای دسته بندی")]
        Category =3,
        [Display(Name = "تخفیف برای مشتری")]
        Customer =4,
        [Display(Name = "تخفیف برای برند")]
        Brand =5,
    }
    public enum DiscountLimitation
    {
        [Display(Name = "بدونه محدودیت تعداد")]
        Unlimited = 0,
        [Display(Name = "فقط N بار")]
        NTimeOnly = 1,
        [Display(Name = "N بار به ازای هر مشتری")]
        NTimePerCustomer = 2,
    }
}

