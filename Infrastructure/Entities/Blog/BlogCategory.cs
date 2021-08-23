using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Infrastructure.Entities
{
  public  class BlogCategory : BaseEntity
    {
        [Required]
        [StringLength(50)]
        public string Title { get; set; }
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
        public ICollection<BlogPost> Posts { get; set; }
    }
}
