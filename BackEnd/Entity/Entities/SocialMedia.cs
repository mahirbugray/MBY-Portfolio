using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class SocialMedia : BaseEntity
    {
        public string SocialMediaUrl { get; set; }
        public string SocialMediaIcon { get; set; }
        public bool IsApproved { get; set; }
    }
}
