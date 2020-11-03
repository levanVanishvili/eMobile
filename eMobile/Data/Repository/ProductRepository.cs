using eMobile.Data.Repository.IRepository;
using eMobile.Models;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eMobile.Data.Repository
{
    public class ProductRepository: Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _db;

        public ProductRepository(ApplicationDbContext db): base(db)
        {
            _db = db;
        }
        
        public void Update(Product product)
        {
            var objFromDb = _db.Products.FirstOrDefault(i => i.Id == product.Id);
            if (objFromDb!=null)
            {
                if (product.FileUrl != null)
                {
                    objFromDb.FileUrl = product.FileUrl;
                }

                objFromDb.Name = product.Name;
                objFromDb.Weight = product.Weight;
                objFromDb.RomMemory = product.RomMemory;
                objFromDb.Resolution = product.Resolution;
                objFromDb.DisplaySize = product.DisplaySize;
                objFromDb.Price = product.Price;
                objFromDb.CPU = product.CPU;
                objFromDb.Dimensions = product.Dimensions;
                objFromDb.OpSystemId = product.OpSystemId;
                objFromDb.BrandId = product.BrandId;

            }           
        }
    }
}
