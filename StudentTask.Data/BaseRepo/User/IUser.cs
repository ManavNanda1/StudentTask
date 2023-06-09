using StudentTask.Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentTask.Data.BaseRepo.User
{
    public  interface IUser
    {
        Task<LoginModel> LogCheck(LoginModel LogData);
    }
}
