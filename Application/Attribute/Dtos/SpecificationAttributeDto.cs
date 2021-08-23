using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Attribute.Dtos
{
   public class SpecificationAttributeDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "فیلد {0} ضروری میباشد")]
        [Display(Name = "عنوان")]
        public string Name { get; set; }
        [Display(Name = "ترتیب تمایش")]
        public int DisplayOrder { get; set; }
    }
}
