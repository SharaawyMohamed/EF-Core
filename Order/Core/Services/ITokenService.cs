﻿using Core.Models.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface ITokenService
    {
       public  Task<string> GenerateToken(AppUser user, UserManager<AppUser> userManager);
    }
}
