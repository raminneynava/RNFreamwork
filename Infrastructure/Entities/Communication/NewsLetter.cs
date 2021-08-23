using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Communication
{
    public class NewsLetter : BaseEntity
    {
        public string Contact { get; set; }
    }
}
