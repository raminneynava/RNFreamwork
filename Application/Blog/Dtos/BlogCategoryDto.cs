using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Blog.Dtos
{
   public class BlogCategoryDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "فیلد {0} ضروری میباشد")]
        [Display(Name = "عنوان")]
        public string Title { get; set; }
        [Display(Name = "فعال/غیر فعال")]
        public bool IsActive { get; set; }
        [Display(Name = "ترتیب تمایش")]
        public int Order { get; set; }
        [Display(Name = "تصویر")]
        public string Image { get; set; }
        #region Seo
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
        #endregion
    }
}
