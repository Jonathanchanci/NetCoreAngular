using NetCoreAngular.Models;
using System.Collections.Generic;

namespace NetCoreAngular.BussinessLogic.Interfaces
{
    public interface ICustomerLogic
    {
        Customer GetById(int id);
        IEnumerable<Customer> GetList();
        IEnumerable<CustomerList> CustomerPageList(int page, int rows);
        int Insert(Customer customer);
        bool Update(Customer customer);
        bool Delete(Customer customer);
    }
}
