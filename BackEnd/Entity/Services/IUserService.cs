﻿using Entity.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Services
{
    public interface IUserService
    {
        Task<UserDto> GetByIdUser(int id);
        Task<UpdateUserDto> UpdateProfileInformation(UpdateUserDto model);
        Task<List<UserDto>> GetAllUsers();
        Task<UserDto> GetByUserName(string userName);
    }
}
