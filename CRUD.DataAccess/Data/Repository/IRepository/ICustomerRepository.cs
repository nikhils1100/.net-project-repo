using CRUD.DataAccess.Data.IRepository;
using CRUD_NwDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.DataAccess.Data.Repository.IRepository
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        void Update(Customer customer);
    }
}
