using StudentTask.Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentTask.Services.User
{
    public  interface IUserService
    {
        Task<LoginModel> LogCheck(LoginModel LogData);
    }
}
