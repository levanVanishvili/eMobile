using eMobile.Data.Repository.IRepository;
using eMobile.Models;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eMobile.Data.Repository
{
    public class OpSystemRepository: Repository<OpSystem>,IOpSystemRepository 
    {
        private readonly ApplicationDbContext _db;

        public OpSystemRepository(ApplicationDbContext db): base(db)
        {
            _db = db;
        }
        
        public void Update(OpSystem opSystem)
        {
            var objFromDb = _db.OperatingSystems.FirstOrDefault(i => i.Id == opSystem.Id);
            if (objFromDb!=null)
            {
                objFromDb.Name = opSystem.Name;
            }           
        }
    }
}
