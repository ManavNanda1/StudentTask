using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using StudentTask.Model.Data;
using StudentTask.Model.User;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentTask.Data.BaseRepo.User
{
    public class UserData : BaseRepository , IUser
    {

        #region Fields
        private IConfiguration _config;
        #endregion

        #region Controler For Repo Use
        public UserData(IConfiguration config, IOptions<DataConfig> dataconfig) : base(config)
        {
            _config = config;
        }
        #endregion

        #region Methods 

        public async Task<LoginModel> LogCheck(LoginModel LogData)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@Email", LogData.Email);
                param.Add("@Password", LogData.Password);
                LoginModel model = await QueryFirstOrDefaultAsync<LoginModel>("Sp_LoginCheck", param, commandType: CommandType.StoredProcedure);
                return model;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
