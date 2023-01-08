using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarWashBackend.Models;

namespace CarWashBackend.Repository
{
    public interface IPackageRepository<TEntity>
    {
        IEnumerable<TEntity> Get();

        Package GetById(int id);

        void Add(TEntity user);

        void Delete(int Id);

        void Update(int Id, Package package);
        void SaveChanges();
    }
}