using FluentAssertions;
using NetCoreAngular.BussinessLogic.Implementations;
using NetCoreAngular.BussinessLogic.Interfaces;
using NetCoreAngular.UnitOfWork;
using Northwind.BusinessLogicTest.Mocked;
using Xunit;

namespace Northwind.BusinessLogicTest
{
    public class CustomerLogicTest
    {
        private readonly IUnitOfWork _unitMocked;
        private readonly ICustomerLogic _customerLogic;
        public CustomerLogicTest()
        {
            var unitMocked = new CustomerRepositoryMocked();
            _unitMocked = unitMocked.GetInstance();
            _customerLogic = new CustomerLogic(_unitMocked);
        }

        [Fact]
        public void GetById_Customer_Test()
        {
            var result = _customerLogic.GetById(1);

            result.Should().NotBeNull();
            result.Id.Should().BeGreaterThan(0);
        }
    }
}
