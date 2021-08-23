using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Attribute
{
  public class CategoryAttributeAnswer:BaseEntity
    {
        public string Answer { get; set; }
        public string ColorCode { get; set; }
        public int CategoryAttributeSpeciId { get; set; }
        [ForeignKey(nameof(CategoryAttributeSpeciId))]
        public CategoryAttributeSpeci CategoryAttributeSpeci { get; set; }
    }
}
