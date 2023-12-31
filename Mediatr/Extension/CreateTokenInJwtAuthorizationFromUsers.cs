﻿using Mediator.Domains;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Mediator.Extension;

public class CreateTokenInJwtAuthorizationFromUsers
{
    public static readonly IHttpContextAccessor HttpContextAccessor;
    public static string CreateToken(UserDetail user, List<Claim> claims)
    {
        claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("asfsafsasafjsafjksafksafsafsafsafasfasfafasfsafasfsafsafassaf"));

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddHours(7),
            signingCredentials: creds,
            issuer: "http://localhost:7058/"
        );
        var jwt = new JwtSecurityTokenHandler().WriteToken(token);
        return jwt;
    }
}
