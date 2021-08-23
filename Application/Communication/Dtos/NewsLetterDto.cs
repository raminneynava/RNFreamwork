using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Application.Communication.Dtos
{
    public class NewsLetterDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "فیلد {0} ضروری میباشد")]
        [EmailAddress(ErrorMessage = "فیلد {0} ضروری میباشد")]
        //[Remote()]
        [Display(Name = "عنوان")]
        public string Contact { get; set; }
    }
}
