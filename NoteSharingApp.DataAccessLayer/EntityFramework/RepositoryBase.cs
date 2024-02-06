using NoteSharingApp.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NoteSharingApp.DataAccessLayer.EntityFramework
{
    internal static class RepositoryBase
    {
        private static DatabaseContext _db;
        private static object locksync = new object();

        public static DatabaseContext CreateContext()
        {
            if (_db ==null)
            {
                lock (locksync)
                {
                    if (_db == null)
                    {
                        _db = new DatabaseContext();
                    }
                }
            }

            return _db;
        }
    }
}
