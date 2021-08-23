using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Communication
{
    public class SocialNetwork : BaseEntity
    {
        public string SocialProfile { get; set; }
        public bool IsActive { get; set; }
        public int Order { get; set; } = 0;
        public Socials SocialType { get; set; }
    }
    public enum Socials
    {
        Telegram=1,
        Twitter=2,
        Instagram=3,
        Linkdin=4,
        Aparat=5
    }
}
