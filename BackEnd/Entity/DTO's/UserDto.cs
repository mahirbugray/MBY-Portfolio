using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTO_s
{
    public class UserDto
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateTime? BirthDate { get; set; } // 📌 Nullable hale getirildi
        public bool IsConfirmed { get; set; }
        public string AccessToken { get; set; }
    }
}
