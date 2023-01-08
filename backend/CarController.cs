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
    [RoutePrefix("api/Car")]
    public class CarController : ApiController
    {
        ICarRepository<Car> _car;
        public CarController()
        {
            this._car = new CarRepository(new CarWashEntities());
        }

        //ActionMethod to Create package
        #region
        [HttpPost]
        [Route("")]
        public IHttpActionResult CreateUser(Car car)
        {
            Package carObj = null;
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid data.");
                _car.Add(car);

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
        public IEnumerable<Car> Get()
        {
            var users = _car.Get();
            return users;
        }
        [HttpDelete]
        public IHttpActionResult Delete(int Id)
        {
            _car.Delete(Id);
            if (Id <= 0)
                return BadRequest("Not a valid id");

            return Ok("Deleted successfully");


        }
        #endregion
        //ActionMethod to Update User
        #region
        [HttpPut]
        public IHttpActionResult Update(int Id,Car car)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Not a valid model");
                _car.Update(Id, car);

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
            var user = _car.GetById(Id);
            return user;
        }
        #endregion

    }
}
    


    

