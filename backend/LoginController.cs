using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CarWashBackend.Models;
using System.Web.UI.WebControls;
using CarWashBackend.Repository;

namespace CarWashBackend.Controllers
{
    [RoutePrefix("api/Login")]
    public class LoginController : ApiController
    {
        AccountRepository _accountrepository;
        public LoginController()
        {
            this._accountrepository = new AccountRepository(new CarWashEntities());
        }

        [HttpPost]

        public IHttpActionResult VerifyLogin(UserTable objlogin)
        {
            UserTable user = null;
            try
            {
                user = _accountrepository.VerifyLogin(objlogin.Email, objlogin.Password);

                if (user != null)
                {
                    //return NotFound();
                    return Ok(user);

                }

            }
            catch (Exception)
            {

            }
            return NotFound();

        }


    }
} 

    

