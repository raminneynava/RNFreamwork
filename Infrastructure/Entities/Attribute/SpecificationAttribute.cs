using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Attribute
{
  public class SpecificationAttribute:BaseEntity
    {
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
    }
}
