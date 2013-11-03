using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrudRest.Entity;

namespace Crud.Data
{
    /// <summary>
    /// In memory implementation of customer repository
    /// </summary>
    public class CustomerInMemoryRepository : ICustomerRepository
    {
        public static ICollection<Customer> _data = new List<Customer>(new List<Customer>()
                {
                    new Customer() {Id = 1, Name="Jhon Doe", Email="jhon@mail.com", Address="Evergreen st. # 25"},
                    new Customer() {Id = 2, Name="Jhon Smith", Email="jhons@mail.com", Address="Evergreen st. # 25"},
                    new Customer() {Id = 3, Name="Alice", Email="alice@mail.com", Address="Evergreen st. # 25"},
                    new Customer() {Id = 4, Name="Stuart", Email="stuart@mail.com", Address="Evergreen st. # 25"},
                });

        public CustomerInMemoryRepository()
        {
        }

        public CustomerInMemoryRepository(ICollection<Customer> data)
        {
            _data = data;
        }

        public ICollection<CrudRest.Entity.Customer> Customers
        {
            get
            {
                return _data;
            }
        }

        public CrudRest.Entity.Customer Find(int id)
        {
            var customer = (from c in _data
                            where c.Id == id
                            select c).FirstOrDefault();
            return customer;
        }

        public void Update(CrudRest.Entity.Customer customer)
        {
            if (customer == null)
            {
                throw new NullReferenceException("customer");
            }

            var customerFound = (from c in _data
                                 where c.Id == customer.Id
                                 select c).FirstOrDefault();
            if (customerFound == null)
            {
                return;
            }

            _data.Remove(customer);
            _data.Add(customer);
        }

        public void Delete(CrudRest.Entity.Customer customer)
        {
            if (customer == null)
            {
                throw new NullReferenceException("customer");
            }

            _data.Remove(customer);
        }

        public void Insert(CrudRest.Entity.Customer customer)
        {
            if (customer == null)
            {
                throw new NullReferenceException("customer");
            }

            _data.Add(customer);
        }
    }
}
