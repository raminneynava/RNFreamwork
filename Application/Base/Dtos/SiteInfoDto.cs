using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Base.Dtos
{
   public class SiteInfoDto
    {
        public int Id { get; set; }
        [Display(Name = "عنوان سایت")]
        public string HomeTitle { get; set; }
        [Display(Name = "آدرس")]
        public string Address { get; set; }
        [Display(Name = "FavIcon")]
        public string FavIcon { get; set; }
        [Display(Name = "تلفن")]
        [MaxLength(11)]
        public string Phone { get; set; }
        [Display(Name = "شماره همراه")]
        [MaxLength(11)]
        [MinLength(11)]
        public string Mobile { get; set; }
        [Display(Name = "فکس")]
        [MaxLength(12)]
        public string Fax { get; set; }
        [Display(Name = "ایمیل")]
        [EmailAddress(ErrorMessage ="Invalid Address Email!")]
        public string Email { get; set; }
        [Display(Name = "کد پستی")]
        [MaxLength(11)]
        public string ZipCode { get; set; }
        #region Seo
        [Display(Name = "توضیحات گوگل")]
        public string SeoDescription { get; set; }
        [Display(Name = "کلمات کلیدی")]
        public string SeoKeyword { get; set; }
        [Display(Name = "تصویر گوکل")]
        public string SeoImage { get; set; }
        #endregion
    }
}
