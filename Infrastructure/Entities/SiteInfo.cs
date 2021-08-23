using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities
{
   public class SiteInfo:BaseEntity
    {

        public string HomeTitle { get; set; }
        public string Address { get; set; }
        public string FavIcon { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string ZipCode { get; set; }
        #region Seo
        public string SeoDescription { get; set; }
        public string SeoKeyword { get; set; }
        public string SeoImage { get; set; }
        #endregion

    }
}
