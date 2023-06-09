using StudentTask.Data.BaseRepo.User;
using StudentTask.Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentTask.Services.User
{
    public class UserService : IUserService
    {
        #region Fields
        IUser _LogObj;

        #endregion


        #region Constructor

        public UserService(IUser LogService)
        {
            _LogObj = LogService;

        }
        #endregion

        #region Post Methods

        public async Task<LoginModel> LogCheck(LoginModel LogData)
        {
			try
			{
				return await _LogObj.LogCheck(LogData);
			}
			catch (Exception Ex)
			{

				throw Ex;
			}
        }
        #endregion
    }
}
