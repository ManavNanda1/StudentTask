using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentTask.Filter;
using StudentTask.Model.Student;
using StudentTask.Services.Student;

namespace StudentTask.Controllers
{
    [TypeFilter(typeof(AuthorizationFilter))]
    public class StudentController : Controller
    {

        #region Fields 
        IStudentService StudentObj;
        private readonly IWebHostEnvironment _webHostEnvironment;
        #endregion

        #region Constructor
        public StudentController(IStudentService _obj, IWebHostEnvironment webHostEnvironment)
        {
            StudentObj = _obj;
           _webHostEnvironment = webHostEnvironment;
        }
        #endregion

        #region PostMethods 

        public IActionResult AddStudent()
        {
            try
            {
                return View();
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
       
      
        [HttpPost]
        public async Task<IActionResult> AddStudent(StudentModel StudentData)
        {
            try
            {
                var Images = "Images/UserDefinedImages/";
                Images += StudentData.ProfilePic.FileName + Guid.NewGuid().ToString();
                StudentData.ProfilePicture = Images;
                string ServerFolder = Path.Combine(_webHostEnvironment.WebRootPath, Images);
                await StudentData.ProfilePic.CopyToAsync(new FileStream(ServerFolder, FileMode.Create));
                await StudentObj.AddStudent(StudentData);
                    return RedirectToAction("StudentTable");
               
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }


        public async Task<IActionResult> StudentTable()
        {
            try
            {
                return View(await StudentObj.GetStudentPerPage(1));
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }
        public async Task<List<StudentModel>> GetStudentTable(int Id)
        {
            try
            {
               var  Data = await StudentObj.GetStudentPerPage(Id);
                return Data.ToList();
            }
            catch (Exception Ex)
            {
                throw Ex;
            }    
       }
        public async Task<IActionResult> GetStudentById(int id)
        {
            try
            {
                return View(await StudentObj.GetStudentById(id));
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }

      

        public async Task<IActionResult> EditStudent(int id)
        {
            try
            {
                return View(await StudentObj.GetStudentById(id));
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditStudent(StudentModel StudentData)
        {
            try
            {
                var data = await StudentObj.EditStudent(StudentData);
                return RedirectToAction("StudentTable");

            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }

        

        #endregion

        #region Delete
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await StudentObj.DeleteStudent(id);
                return RedirectToAction("StudentTable");
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

      
    }
}
