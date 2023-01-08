using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using CarWashFrontend.Models;
using CarWashFrontend.Repository;
using Newtonsoft.Json;

namespace CarWashFrontend.Controllers
{
    public class CarController : Controller
    {

        #region
        public async Task<ActionResult> CarDetails()
        {
            List<CarViewModel> cars = new List<CarViewModel>();
            var service = new ServiceRepository();
            {
                using (var response = service.GetResponse("Car"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    cars = JsonConvert.DeserializeObject<List<CarViewModel>>(apiResponse);
                }
            }
            return View(cars);
        }
        #endregion


        //ActionMethod to delete user
        #region
        public async Task<ActionResult> Delete(int Id)
        {
            var service = new ServiceRepository();
            {
                using (var response = service.DeleteResponse("Car/", Id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
            return RedirectToAction("CarDetails");
        }
        #endregion
        //Actionmethod to update user
        #region
        public async Task<ActionResult> Edit(int Id)
        {
            CarViewModel cars = new CarViewModel();
            var service = new ServiceRepository();
            {
                using (var response = service.EditResponse("Car/", Id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    cars = JsonConvert.DeserializeObject<CarViewModel>(apiResponse);
                }
            }
            return View(cars);
        }
        #endregion
        [HttpPost]
        public async Task<ActionResult> Edit(CarViewModel cars)
        {
            CarViewModel car = new CarViewModel();
            var service = new ServiceRepository();
            {
                using (var response = service.EditResponse("Package/", +cars.Id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    car = JsonConvert.DeserializeObject<CarViewModel>(apiResponse);
                }
                return RedirectToAction("PackageDetails");
            }
        }

        #region
        public async Task<ActionResult> Create(CarViewModel cars)
        {
            if (ModelState.IsValid)
            {
                CarViewModel newPackage = new CarViewModel();
                var service = new ServiceRepository();
                {
                    using (var response = service.PostResponse("Car/",cars))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        //newUser = JsonConvert.DeserializeObject<UserViewModel>(apiResponse);
                    }
                }



                return RedirectToAction("Package");
            }
            return View(cars);
        }
        #endregion


    }
}