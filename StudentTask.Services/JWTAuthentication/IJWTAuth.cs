using StudentTask.Model.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentTask.Services.JWTAuthentication
{
    public interface IJWTAuth
    {
        string GenerateToken(string EmailAddress, string UserId, string SecretKey, double JWT_Validity_Mins);
    }
}
