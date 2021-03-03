using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.DataAccess.Data.Repository.IRepository
{
    public interface IUnitOfWork: IDisposable
    {
        ICustomerRepository Customer { get; }
        ISP_call SP_call { get; }
        public void Save();
    }
}
