using Microsoft.AspNetCore.Mvc;
using StudentTask.Data.BaseRepo.User;
using StudentTask.Model.User;
using StudentTask.Services.JWTAuthentication;
using StudentTask.Services.User;

namespace StudentTask.Controllers
{
    public class UserController : Controller
    {
        #region Fields
        public readonly IUserService UserObj;
        public readonly IJWTAuth jWTAuth;
        #endregion


        #region Constructor
        public UserController (IUserService _obj, IJWTAuth jWT)
        {
            UserObj = _obj;
            jWTAuth = jWT;
         
        }
        #endregion

        #region Post Methods 

        

        public IActionResult Login()
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

  
        public ActionResult Logout()
        {
            try
            {
                HttpContext.Session.Clear();
                return RedirectToAction("Login");
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel LogData)
        {
            try
            {
                var res = await UserObj.LogCheck(LogData);
                ModelState.Remove("UserId");
                ModelState.Remove("UserEmail");
                if (res != null && ModelState.IsValid)
                {
                    string JWTToken = jWTAuth.GenerateToken(res.UserEmail, res.UserId.ToString(), "9670FDCB4C17620D9EFECD90BB080852", 5);
                    HttpContext.Session.SetString("_userToken", JWTToken);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Error = "Invalid Credentials";
                    return View();
                }
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }

        #endregion

    }
}
