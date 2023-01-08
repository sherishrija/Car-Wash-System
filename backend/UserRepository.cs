using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarWashBackend.Models;

namespace CarWashBackend.Repository
{
    public class UserRepository:IUser<UserTable>
    {
        CarWashEntities _context;

        public UserRepository(CarWashEntities context)
        {
            _context = context;
        }
        //To Get all Users Method
        #region
        public IEnumerable<UserTable> Get()
        {
            return _context.UserTables.ToList();
        }
        #endregion
        //To add user method
        #region
        public void Add(UserTable user)
        {
            _context.UserTables.Add(user);
            _context.SaveChanges();


        }
        #endregion
        //method to delete user
        #region
        public void Delete(int Id)
        {
            UserTable user = _context.UserTables.Find(Id);
            _context.UserTables.Remove(user);
            _context.SaveChanges();

        }
        #endregion
        //method to update user
        #region
        public void Update(int Id, UserTable user)
        {

            var _user = _context.UserTables.Find(Id);
            _user.Id = user.Id;
            _user.FirstName = user.FirstName;
            _user.LastName = user.LastName;
            _user.PhoneNumber = user.PhoneNumber;
            _user.Email = user.Email;
            _user.Password = user.Password;
            _user.Role = user.Role;
            _user.Status = user.Status;
            _context.Entry(_user).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();


        }
        #endregion

        //method to get user by Id
        #region

        public UserTable GetById(int Id)
        {
            return _context.UserTables.Find(Id);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
        #endregion
    }
}
    
