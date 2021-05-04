using AutoFixture;
using Moq;
using NetCoreAngular.Models;
using NetCoreAngular.Repositories;
using NetCoreAngular.UnitOfWork;
using System.Collections.Generic;
using System.Linq;

namespace Northwind.BusinessLogicTest.Mocked
{
    public class CustomerRepositoryMocked
    {
        private readonly List<Customer> _customers;

        public CustomerRepositoryMocked() {
            _customers = Customers();
        }

        public IUnitOfWork GetInstance()
        {
            var mocked = new Mock<IUnitOfWork>();
            mocked.Setup(u => u.Customer).Returns(GetCustomerRepositoryMocked());

            return mocked.Object;
        }

        public ICustomerRepository GetCustomerRepositoryMocked()
        {
            var customerMocked = new Mock<ICustomerRepository>();
            customerMocked.Setup(c => c.GetById(It.IsAny<int>()))
                .Returns((int id) => _customers.FirstOrDefault(cus => cus.Id == id));

            return customerMocked.Object;
        }

        private List<Customer> Customers()
        {
            var fixture = new Fixture();
            var customers = fixture.CreateMany<Customer>(50).ToList();
            for (int i = 0; i < 50; i++)
            {
                customers[i].Id = i + 1;
            }
            return customers;
        }
    }
}
