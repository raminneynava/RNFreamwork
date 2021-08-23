using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Blog.Dtos
{
  public class BlogPostListDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Status { get; set; }
        public string Category { get; set; }
        public string Rate { get; set; }
        public string AuthorId { get; set; }
    }
}
