using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using CarWashFrontend.Models;
using CarWashFrontend.Repository;
using Newtonsoft.Json;



namespace CarWashFrontend.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult HomePage()
        {
            return View();
        }
        public ActionResult LoginUser()
        {
            return View();
        }


        [HttpPost]
        public async Task<ActionResult> LoginUser(LoginViewModel login)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    LoginViewModel newUser = new LoginViewModel();
                    var service = new ServiceRepository();
                    {
                        using (var response = service.VerifyLogin("api/Login", login))
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            newUser = JsonConvert.DeserializeObject<LoginViewModel>(apiResponse);
                        }
                    }
                    if (newUser != null)
                    {
                        ViewBag.message = "Login Success";
                    }
                    else
                    {
                        ViewBag.message = "incorrect";
                    }
                }
            }
            catch
            {

            }
            return RedirectToAction("AdminPage");

        }


        //This Post Method will validate the userName & Password valid or not using WebAPI
        [HttpPost]
        public ActionResult LoginUsers(UserViewModel Ur)
        {
            if (!(string.IsNullOrEmpty(Ur.Email) || string.IsNullOrEmpty(Ur.Password)))
            {

                if (!ModelState.IsValid)
                {
                    HttpClient hc = new HttpClient();
                    hc.BaseAddress = new Uri("https://localhost:44355/api/Login"); // URL for Login WebAPI
                    var checkLoginDetails = hc.PostAsJsonAsync<UserViewModel>("Login", Ur);//Asynchronosly passing the values in Json Format to API
                    var checkrec = checkLoginDetails.Result;//Checking the User Login ID & Password 

                    //Condition for Successfull Login We need to Navigate  
                    if ((int)checkrec.StatusCode == 200)
                    {
                        ViewBag.message = "Login Success!!";
                    }
                    //Condition for Invalid User Name & Password
                    if ((int)checkrec.StatusCode == 426)
                    {
                        ViewBag.message = "Invalid User Id & Password";
                    }

                }
            }
            return View();

        }
       public ActionResult AdminPage()
        {
            return View();
        }

        //Action method to create user
        #region
        public async Task<ActionResult> Create(UserViewModel user)
        {
            if (ModelState.IsValid)
            {
                UserViewModel newUser = new UserViewModel();
                var service = new ServiceRepository();
                {
                    using (var response = service.PostResponse("Api/Users", user))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        newUser = JsonConvert.DeserializeObject<UserViewModel>(apiResponse);
                    }
                }

                return RedirectToAction("Index", "User");
            }
            return View(user);
        }
        #endregion
    }

}
    
