
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTO_s
{
    public class ConfirmEmailDto
    {
        public string Email { get; set; }
        public int ConfirmCode { get; set; }
    }
}
