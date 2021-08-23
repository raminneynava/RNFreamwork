using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Products.Dto
{
   public class ProductCategoryListDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ParentTitle { get; set; }
        public string Status { get; set; }
        public int Level { get; set; }
    }
}
