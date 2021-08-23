using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Attribute.Dtos
{
   public class CategoryAttributeSpeciDto
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        [Display(Name = "مشخصه")]
        public int AttributeId { get; set; }
        [Display(Name = "چند انتخابی")]
        public bool IsSelectList { get; set; }
        [Display(Name = "فیلد رنگ")]
        public bool IsColor { get; set; }
        [Display(Name = "نمایش در فیلتر")]
        public bool isFilter { get; set; }

    }
}
