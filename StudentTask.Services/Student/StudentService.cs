using StudentTask.Data.BaseRepo.Student;
using StudentTask.Model.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentTask.Services.Student
{
    public class StudentService : IStudentService
    {
        #region Fields
        IStudent StudentObj;
        #endregion

        #region Constructor
        public StudentService(IStudent _obj)
        {
            StudentObj = _obj;
        }
        #endregion

        #region Post methods 
        public async Task<int> AddStudent(StudentModel StudentData)
        {
            try
            {
                return await StudentObj.AddStudent(StudentData);
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
                return await StudentObj.EditStudent(StudentData);
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
                return await StudentObj.GetStudentById(id); 
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
                return await StudentObj.GetStudentTable();
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }

        #endregion

        #region Delete
        public async Task<int> DeleteStudent(int Id)
        {
            try
            {
                return await StudentObj.DeleteStudent(Id);
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
                return await StudentObj.GetStudentPerPage(PageNo);
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
                return await StudentObj.GetStudentPerPagesTwo(PageNo, NoOfPageWant);
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }
        #endregion
    }
}
