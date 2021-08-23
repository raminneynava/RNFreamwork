using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Eshop
{
   public class DiscountProduct
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int DiscountId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }
        [ForeignKey(nameof(DiscountId))]
        public Discount Discount { get; set; }
    }
}
