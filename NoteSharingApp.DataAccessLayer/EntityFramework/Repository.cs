using NoteSharingApp.DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;

namespace NoteSharingApp.DataAccessLayer.EntityFramework
{
    public class Repository<T> : IDataAccess<T> where T : class
    {
        private DatabaseContext db;
        private DbSet<T> set;

        public Repository()
        {
            db = RepositoryBase.CreateContext();
            set = db.Set<T>();
        }

        public List<T> List()
        {
            return set.ToList();
        }

        public IQueryable<T> ListQueryable()
        {
            return set.AsQueryable<T>();
        }

        public List<T> List(Expression<Func<T, bool>> where)
        {
            return set.Where(where).ToList();
        }

        public int Insert(T obj)
        {
            set.Add(obj);
            return Save();
        }

        public int Update(T obj)
        {
            set.AddOrUpdate<T>(obj);
            return Save();
        }

        public int Delete(T obj)
        {
            set.Remove(obj);
            return Save();
        }

        public int Save()
        {
            return db.SaveChanges();
        }

        public T Find(Expression<Func<T, bool>> where)
        {
            return set.FirstOrDefault(where);
        }
    }
}
