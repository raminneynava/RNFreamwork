using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Content.Dtos
{
   public class PageContentDto
    {
        public int Id { get; set; }
        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "فیلد {0} ضروری میباشد")]
        public string Title { get; set; }
        [Display(Name = "متن")]
        public string Content { get; set; }
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
