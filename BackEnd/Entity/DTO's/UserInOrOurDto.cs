﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTO_s
{
    public class UsersInOrOutDto
    {
        public RoleDto Role { get; set; }
        public List<UserDto> UsersInRole { get; set; }
        public List<UserDto> UsersOutRole { get; set; }
    }
}
