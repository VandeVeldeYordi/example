﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Pri.Festivals.Core.InterFaces.Services
{
    public interface IJwtService
    {
        JwtSecurityToken GenerateToken(List<Claim> userClaims);
        string SerializeToken(JwtSecurityToken token);
    }
}
