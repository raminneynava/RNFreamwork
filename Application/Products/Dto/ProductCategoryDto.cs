using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.Products.Dto
{
  public class ProductCategoryDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="فیلد {0} ضروری میباشد")]
        [Display(Name ="عنوان")]
        public string Title { get; set; }
        [Display(Name = "توضیحات")]
        public string Description { get; set; }
        [Display(Name = "تصویر")]
        public string Image{ get; set; }
        [Display(Name = "گروه اصلی")]
        public int? ParentCategoryId { get; set; }
        [Display(Name = "فعال/غیر فعال")]
        [Required(ErrorMessage = "فیلد {0} ضروری میباشد")]
        public bool IsActive { get; set; }
        [Display(Name = "ترتیب تمایش")]
        public int Order { get; set; }
        [Required(ErrorMessage = "فیلد {0} ضروری میباشد")]
        [Display(Name = "عنوان صفحه")]
        public string SeoTitle { get; set; }
        [Required(ErrorMessage = "فیلد {0} ضروری میباشد")]
        [Display(Name = "آدرس صفحه")]
        public string SeoUrl { get; set; }
        [Display(Name = "توضیحات گوگل")]
        public string SeoDescription { get; set; }
        [Display(Name = "کلمات کلیدی")]
        public string SeoKeyword { get; set; }
        [Display(Name = "تصویر گوکل")]
        public string SeoImage { get; set; }
    }
}
