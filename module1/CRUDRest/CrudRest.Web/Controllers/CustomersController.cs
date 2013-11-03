using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Crud.Data;
using CrudRest.Entity;

namespace CrudRest.Web.Controllers
{
    public class CustomersController : ApiController
    {
        private ICustomerRepository _repository;

        public CustomersController(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public CustomersController()
        {
            _repository = new CustomerInMemoryRepository();
        }

        public ICollection<Customer> GetCustomers()
        {
            return _repository.Customers;
        }

        public Customer GetCustomer(int id)
        {
            var customer = _repository.Find(id);
            if (customer == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return customer;
        }

        public HttpResponseMessage PostCustomer(Customer customer)
        {
            var customerFound = _repository.Find(customer.Id);
            if (customerFound != null)
            {
                throw new HttpResponseException(HttpStatusCode.Forbidden);
            }

            _repository.Insert(customer);
            var response = Request.CreateResponse<Customer>(HttpStatusCode.Created, customer);
            response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = customer.Id }));
            return response;
        }

        public HttpResponseMessage DeleteCustomer(int id)
        {
            var customerFound = _repository.Find(id);
            if (customerFound != null)
            {
                throw new HttpResponseException(HttpStatusCode.Forbidden);
            }

            _repository.Delete(new Customer() { Id = id });
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        public Customer PutCustomer(Customer customer)
        {
            var customerFound = _repository.Find(customer.Id);
            if (customerFound == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _repository.Update(customer);
            return customer;
        }

    }
}
