using eMobile.Data.Repository.IRepository;
using eMobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eMobile.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            OpSystem = new OpSystemRepository(_db);
        }

        public IOpSystemRepository OpSystem { get; private set; }

        public IOpSystemRepository opSystem => throw new NotImplementedException();

        public void Dispose()
        {
            _db.Dispose(); 
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
