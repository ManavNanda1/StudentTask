using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using StudentTask.Model.Data;
using StudentTask.Model.Student;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentTask.Data.BaseRepo.Student
{
    public class StudentData : BaseRepository , IStudent
    {

        #region Fields
        private IConfiguration _config;
        #endregion

        #region Constructor
        public StudentData(IConfiguration config, IOptions<DataConfig> dataconfig) : base(config)
        {
            _config = config;
        }
        #endregion


        #region Post Methods 
        public async Task<int> AddStudent(StudentModel StudentData)
        {
			try
			{
				var Param = new DynamicParameters();
				Param.Add("@Firstname", StudentData.FirstName);
				Param.Add("@Lastname", StudentData.LastName);
				Param.Add("@Gender", StudentData.Gender);
				Param.Add("@Email", StudentData.EmailId);
				Param.Add("@Password", StudentData.Password);
				Param.Add("@profilePic", StudentData.ProfilePicture);
				Param.Add("@Skills", StudentData.Skills);
				Param.Add("@Remarks", StudentData.Remarks);
				Param.Add("@Country", StudentData.Country);
                return await QueryFirstOrDefaultAsync<int>("Sp_AddStudent", Param, commandType: System.Data.CommandType.StoredProcedure);


            }
			catch (Exception Ex)
			{

				throw Ex;
			}
        }

       

        public async Task<long> EditStudent(StudentModel StudentData)
        {
            try
            {
                var Param = new DynamicParameters();
                Param.Add("@id", StudentData.Id);
                Param.Add("@Firstname", StudentData.FirstName);
                Param.Add("@Lastname", StudentData.LastName);
                Param.Add("@Gender", StudentData.Gender);
                Param.Add("@Email", StudentData.EmailId);
                Param.Add("@Password", StudentData.Password);
                Param.Add("@profilePic", StudentData.ProfilePicture);
                Param.Add("@Skills", StudentData.Skills);
                Param.Add("@Remarks", StudentData.Remarks);
                Param.Add("@Country", StudentData.Country);
                var data = await QueryFirstOrDefaultAsync<long>("Sp_EditStudent", Param, commandType: CommandType.StoredProcedure);
                return data;
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }

        public async Task<StudentModel> GetStudentById(int id)
        {
			try
			{
                var param = new DynamicParameters();
                param.Add("@id", id);
                var data = await QueryFirstOrDefaultAsync<StudentModel>("Sp_GetStudentById", param, commandType: CommandType.StoredProcedure);
                return data;
            }
			catch (Exception Ex)
			{

				throw Ex;
			} 
        }

        public async Task<List<StudentModel>> GetStudentTable()
        {
			try
			{
     
                var data = await QueryAsync<StudentModel>("Sp_GetStudentTable", commandType: System.Data.CommandType.StoredProcedure);
                return data.ToList();
            }
			catch (Exception Ex)
			{

				throw Ex;
			}
        }
        #endregion

        #region Delete 
        public async Task<int> DeleteStudent(int id)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@id", id);
                return await QueryFirstOrDefaultAsync<int>("Sp_DeleteStudent", param, commandType: System.Data.CommandType.StoredProcedure);
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }

        public async Task<List<StudentModel>> GetStudentPerPage(int PageNo)
        {
            try
            {
                var Param = new DynamicParameters();
                Param.Add("@PageNo", PageNo);
                return (List<StudentModel>)await QueryAsync<StudentModel>("GetPaginatedStudents",Param ,commandType: System.Data.CommandType.StoredProcedure);
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }

        public async Task<List<StudentModel>> GetStudentPerPagesTwo(int PageNo, int NoOfPageWant)
        {
            try
            {
                var Param = new DynamicParameters();
                Param.Add("@PageNo", PageNo);
                Param.Add("@DataToShowNumbwer", NoOfPageWant);
                return (List<StudentModel>)await QueryAsync<StudentModel>("GetPaginatedStudents", Param,commandType: System.Data.CommandType.StoredProcedure);
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }
        #endregion

    }
}
