using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Eshop.Dtos
{
   public class AddDiscountDto
    {
        [Required(ErrorMessage = "فیلد {0} ضروری میباشد")]
        [Display(Name = "عنوان")]
        public string Title { get; set; }
        [Display(Name = "استفاده از درصد؟")]
        public bool UsePercentage { get; set; }//true is percemt
        [Display(Name = "درصد تخفیف")]
        public int DiscountPercentage { get; set; }
        [Display(Name = "مبلغ تخفیف")]
        public int DisscountAmmount { get; set; }
        [Display(Name = "زمان شروع")]
        public string StartDate { get; set; }
        [Display(Name = "زمان انقضا")]
        public string EndDate { get; set; }
        [Display(Name = "استفاده از کوپن")]
        public bool RequiredCoponeCode { get; set; }
        [Display(Name = "کد کوپن")]
        public string CoponCode { get; set; }
        [Display(Name = "نوع تخفیف")]
        public int DiscountTypeId { get; set; }
        [Display(Name = "محدودیت تخفیف")]
        public int LimitationTime { get; set; }
        [Display(Name = "تعداد کد تخفیف")]
        public int DiscountLimitationId { get; set; }
        [Display(Name = "اعمال برای محصول")]
        public List<int> AppliedProducts { get; set; }
        [Display(Name = "اعمال برای گروه")]
        public List<int> AppliedCategorys { get; set; }

    }
}
