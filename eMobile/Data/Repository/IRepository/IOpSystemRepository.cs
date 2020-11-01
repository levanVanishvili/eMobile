using eMobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eMobile.Data.Repository.IRepository
{
    public interface IOpSystemRepository: IRepository<OpSystem>
    {
        void Update(OpSystem opSystem);
    }
}
