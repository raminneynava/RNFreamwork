using Infrastructure.Entities.Communication;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Communication.Dtos
{
    public class SocialNetworkDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "فیلد {0} ضروری میباشد")]
        [Display(Name = "آیدی")]
        public string SocialProfile { get; set; }
        [Required(ErrorMessage = "فیلد {0} ضروری میباشد")]
        [Display(Name = "شبکه اجتماعی")]
        public Socials SocialType { get; set; }

        [Display(Name = "فعال/غیر فعال")]
        public bool IsActive { get; set; }
        [Display(Name = "ترتیب تمایش")]
        public int Order { get; set; }
    }
}
