using NetCoreAngular.Models;
using System.Collections.Generic;

namespace NetCoreAngular.Repositories
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        IEnumerable<CustomerList> CustomerPagedList(int page, int rows);
    }
}
