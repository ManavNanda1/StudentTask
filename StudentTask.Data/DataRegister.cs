using StudentTask.Data.BaseRepo.Student;
using StudentTask.Data.BaseRepo.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentTask.Data
{
    public class DataRegister
    {
        public static Dictionary<Type, Type> GetTypes()
        {
            var type = new Dictionary<Type, Type>()
            {
                { typeof(IUser), typeof(UserData) },
                {typeof(IStudent),typeof(StudentData) },
               
            };
            return type;
        }
    }
}
