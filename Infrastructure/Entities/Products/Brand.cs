using Infrastructure.Entities.Eshop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Products
{
   public class Brand:BaseEntity
    {
        public string Title { get; set; }
        public string EnTitle { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public int Order { get; set; } = 0;
        public string Image { get; set; }
        #region Seo
        public string SeoTitle { get; set; }
        public string SeoUrl { get; set; }
        public string SeoDescription { get; set; }
        public string SeoKeyword { get; set; }
        public string SeoImage { get; set; }
        #endregion
        public ICollection<Product> MyProperty { get; set; }
    }
}
