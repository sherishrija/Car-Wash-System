using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarWashBackend.Models;

namespace CarWashBackend.Repository
{
    public class PackageRepository:IPackageRepository<Package>
    {
        CarWashEntities _context;
        public PackageRepository(CarWashEntities context)
        {
            _context = context;
        }
        //To Get all packages
        #region
        public IEnumerable<Package> Get()
        {
            return _context.Packages.ToList();
        }
        #endregion
        //To add  a package
        #region
        public void Add(Package package)
        {
            _context.Packages.Add(package);
            _context.SaveChanges();


        }
        #endregion
        //method to delete package
        #region
        public void Delete(int Id)
        {
            Package package = _context.Packages.Find(Id);
            _context.Packages.Remove(package);
            _context.SaveChanges();

        }
        #endregion
        //method to update package
        #region
        public void Update(int Id, Package package)
        {

            var _package = _context.Packages.Find(Id);
            _package.Id = package.Id;
            _package.Name = package.Name;
            _package.Description = package.Description;
            _package.Price = package.Price;
            _package.Status = package.Status;
            _context.Entry(_package).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();


        }
        #endregion

        //method to get package by Id
        #region

        public Package GetById(int Id)
        {
            return _context.Packages.Find(Id);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
        #endregion
    }
}
    
