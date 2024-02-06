using NoteSharingApp.DataAccessLayer.Abstract;
using NoteSharingApp.DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace NoteSharingApp.BusinessLayer.Abstract
{
    public class ManagerBase<T> : IDataAccess<T> where T : class
    {
        private Repository<T> repository = new Repository<T>();
        public int Delete(T obj)
        {
            return repository.Delete(obj);
        }

        public T Find(Expression<Func<T, bool>> where)
        {
            return repository.Find(where);
        }


        public int Insert(T obj)
        {
            return repository.Insert(obj);
        }

        public List<T> List()
        {
            return repository.List();
        }

        public List<T> List(Expression<Func<T, bool>> where)
        {
            return repository.List(where);
        }

        public IQueryable<T> ListQueryable()
        {
            return repository.ListQueryable();
        }

        public int Save()
        {
            return repository.Save();
        }

        public int Update(T obj)
        {
            return repository.Update(obj);
        }
    }
}
