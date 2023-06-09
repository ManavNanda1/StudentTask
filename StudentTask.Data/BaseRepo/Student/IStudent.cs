using Microsoft.AspNetCore.Http;
using StudentTask.Model.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentTask.Data.BaseRepo.Student
{
    public interface IStudent
    {
        Task<int> AddStudent(StudentModel StudentData);
        Task<List<StudentModel>> GetStudentTable();

        Task<StudentModel> GetStudentById(int id);

        Task<int> DeleteStudent(int Id);

        Task<long> EditStudent(StudentModel StudentData);

        Task<List<StudentModel>>GetStudentPerPage(int PageNo);

        Task<List<StudentModel>> GetStudentPerPagesTwo(int PageNo, int NoOfPageWant);
    }
}
