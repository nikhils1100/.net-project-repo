using CRUD.DataAccess.Data.Repository.IRepository;
using CRUD_NwDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.DataAccess.Data.Repository
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        private readonly ApplicationDbContext _db;
        
        public CustomerRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Customer customer)
        {
            try
            {
                var objFromDb = _db.Customer.FirstOrDefault(s => s.CustomerId == customer.CustomerId);
                if (objFromDb != null)
                {
                    objFromDb.CompanyName = customer.CompanyName;
                    objFromDb.Address = customer.Address;
                    objFromDb.City = customer.City;
                    objFromDb.Region = customer.Region;
                    objFromDb.PostalCode = customer.PostalCode;
                    objFromDb.Country = customer.Country;
                    objFromDb.Phone = customer.Phone;
                    objFromDb.Fax = customer.Fax;
                    _db.SaveChanges();
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                throw new Exception();
            }
        }
    }
}
