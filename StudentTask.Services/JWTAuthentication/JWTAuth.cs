using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using StudentTask.Model.Token;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace StudentTask.Services.JWTAuthentication
{
    public class JWTAuth : IJWTAuth
    {
        public string GenerateToken(string EmailAddress, string UserId, string SecretKey, double JWT_Validity_Mins)
        {
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("EmailAddress",EmailAddress),
                    new Claim("UserId",UserId)
                }),
                Expires = DateTime.Now.AddMinutes(JWT_Validity_Mins),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey)), SecurityAlgorithms.HmacSha256Signature)
            };
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(securityToken);
        }
    }
}
