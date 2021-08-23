using Infrastructure.Entities.Communication;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Communication.Dtos
{
    public class SocialNetworkListDto
    {
        public int Id { get; set; }
        public string SocialProfile { get; set; }
        public string SocialType { get; set; }
        public string Status { get; set; }
        public string Order { get; set; }
    }
}
