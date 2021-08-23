using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Products.Dto
{
  public  class ProductListDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string CategoryTitle { get; set; }
        public string Status { get; set; }
        public string Price { get; set; }
        public string OldPrice { get; set; }
        public string PercentDiscount { get; set; }
    }
}
