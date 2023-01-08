using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarWashBackend.Models;

namespace CarWashBackend.Repository
{
    internal interface IUser<TEntity>
    {
        IEnumerable<TEntity> Get();

        UserTable GetById(int id);

        void Add(TEntity user);

        void Delete(int Id);

        void Update(int Id, UserTable user);
        void SaveChanges();
    }
}
