using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Content
{
    public class PageContent:BaseEntity
    {
        public string Title { get; set; }
        public string Key { get; set; }
        public string Content { get; set; }
        #region Seo
        public string SeoTitle { get; set; }
        public string SeoUrl { get; set; }
        public string SeoDescription { get; set; }
        public string SeoKeyword { get; set; }
        public string SeoImage { get; set; }
        #endregion
    }
}
