using StudentTask.Services.JWTAuthentication;
using StudentTask.Services.Student;
using StudentTask.Services.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentTask.Services
{
    public class RegisterServicesss
    {
        public static Dictionary<Type, Type> GetTypes()
        {
            var type = new Dictionary<Type, Type>()
            {
                { typeof(IUserService), typeof(UserService) },
                {typeof(IStudentService), typeof(StudentService) },
                {typeof(IJWTAuth), typeof(JWTAuth) }

            };
            return type;
        }
    }
}
