using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eMobile.Data.Repository.IRepository
{
    public interface IUnitOfWork: IDisposable
    {
        IOpSystemRepository OpSystem { get; }
        IBrandRepository Brand { get; }
        IProductRepository Product { get; }

        void Save();
    }
}
