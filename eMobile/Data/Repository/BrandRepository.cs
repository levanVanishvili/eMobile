using eMobile.Data.Repository.IRepository;
using eMobile.Models;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eMobile.Data.Repository
{
    public class BrandRepository: Repository<Brand>,IBrandRepository 
    {
        private readonly ApplicationDbContext _db;

        public BrandRepository(ApplicationDbContext db): base(db)
        {
            _db = db;
        }
        
        public void Update(Brand brand)
        {
            var objFromDb = _db.Brands.FirstOrDefault(i => i.Id == brand.Id);
            if (objFromDb!=null)
            {
                objFromDb.Name = brand.Name;
            }           
        }
    }
}
