using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CarWashBackend.Models;
using CarWashBackend.Repository;

namespace CarWashBackend.Controllers
{
    [RoutePrefix("api/Package")]
    public class PackageController : ApiController
    {
        IPackageRepository<Package> _package;
        public PackageController()
        {
            this._package = new PackageRepository(new CarWashEntities());
        }

        //ActionMethod to Create package
        #region
        [HttpPost]
        [Route("")]
        public IHttpActionResult CreateUser(Package package)
        {
            Package packageObj = null;
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid data.");
                _package.Add(package);

            }
            catch (Exception)
            {
                throw;
            }
            return Ok("Saved Successfully");


        }
        #endregion
        //ActionMethod To Get all packages
        #region

        [HttpGet]
        [Route("")]
        public IEnumerable<Package> Get()
        {
            var users = _package.Get();
            return users;
        }
        [HttpDelete]
        public IHttpActionResult Delete(int Id)
        {
            _package.Delete(Id);
            if (Id <= 0)
                return BadRequest("Not a valid id");

            return Ok("Deleted successfully");


        }
        #endregion
        //ActionMethod to Update User
        #region
        [HttpPut]
        public IHttpActionResult Update(int Id, Package package)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Not a valid model");
                _package.Update(Id, package);

            }
            catch (Exception)
            {
                throw;
            }
            return Ok("Updated Successfully");




        }
        #endregion
        //ActionMethod to get User by Id
        #region
        [HttpGet]
        public Package GetById(int Id)
        {
            var user = _package.GetById(Id);
            return user;
        }
        #endregion

    }
}
    

