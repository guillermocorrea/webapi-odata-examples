using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrudRest.Entity;

namespace Crud.Data
{
    public interface ICustomerRepository
    {
        ICollection<Customer> Customers { get; }
        Customer Find(int id);
        void Update(Customer customer);
        void Delete(Customer customer);
        void Insert(Customer customer);
    }
}
