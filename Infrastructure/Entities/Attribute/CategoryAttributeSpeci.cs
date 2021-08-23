using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Attribute
{
   public class CategoryAttributeSpeci:BaseEntity
    {
        public int CategoryId { get; set; }
        public int AttributeId { get; set; }
        public bool IsSelectList { get; set; }
        public bool IsColor { get; set; }
        public bool isFilter { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public ProductCategory ProductCategory { get; set; }
        [ForeignKey(nameof(AttributeId))]
        public SpecificationAttribute Attributes { get; set; }
    }
}
