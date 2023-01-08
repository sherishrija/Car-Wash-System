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
    public class PackageController : Controller
    {
        #region
        public async Task<ActionResult> PackageDetails()
        {
            List<PackageViewModel> packages = new List<PackageViewModel>();
            var service = new ServiceRepository();
            {
                using (var response = service.GetResponse("Package"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    packages = JsonConvert.DeserializeObject<List<PackageViewModel>>(apiResponse);
                }
            }
            return View(packages);
        }
        #endregion


        //ActionMethod to delete package
        #region
        public async Task<ActionResult> Delete(int Id)
        {
            var service = new ServiceRepository();
            {
                using (var response = service.DeleteResponse("Package/", Id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
            return RedirectToAction("PackageDetails");
        }
        #endregion
        //Actionmethod to update package
        #region
        public async Task<ActionResult> Edit(int Id)
        {
            PackageViewModel package = new PackageViewModel();
            var service = new ServiceRepository();
            {
                using (var response = service.EditResponse("Package/", Id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    package = JsonConvert.DeserializeObject<PackageViewModel>(apiResponse);
                }
            }
            return View(package);
        }
        #endregion
        [HttpPost]
        public async Task<ActionResult> Edit(PackageViewModel package)
        {
            PackageViewModel packages=new PackageViewModel();
            var  service=new ServiceRepository();
            {
                using (var response = service.EditResponse("Package/", +package.Id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    package = JsonConvert.DeserializeObject<PackageViewModel>(apiResponse);
                }
                return RedirectToAction("PackageDetails");
            }
        }

        #region
        public async Task<ActionResult> Create(PackageViewModel package)
        {
            if (ModelState.IsValid)
            {
                PackageViewModel newPackage = new PackageViewModel();
                var service = new ServiceRepository();
                {
                    using (var response = service.PostResponse("Package/", package))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        //newUser = JsonConvert.DeserializeObject<UserViewModel>(apiResponse);
                    }
                }



                return RedirectToAction( "Package");
            }
            return View(package);
        }
        #endregion




    }
}
       