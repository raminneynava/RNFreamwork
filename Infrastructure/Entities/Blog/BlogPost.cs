using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Infrastructure.Entities
{
    public class BlogPost : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public string AuthorId { get; set; }
        public string Image { get; set; }
        public bool IsActive { get; set; }
        public int Order { get; set; } = 0;
        #region Seo
        public string SeoTitle { get; set; }
        public string SeoUrl { get; set; }
        public string SeoDescription { get; set; }
        public string SeoKeyword { get; set; }
        public string SeoImage { get; set; }
        #endregion

        [ForeignKey(nameof(CategoryId))]
        public BlogCategory Category { get; set; }

    }

}

