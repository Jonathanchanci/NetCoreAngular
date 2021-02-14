

using NetCoreAngular.Repositories;
using NetCoreAngular.UnitOfWork;

namespace NetCoreAngular.DataAccess
{
    public class NorthwindUnitOfWork : IUnitOfWork
    {
        public NorthwindUnitOfWork(string connectionString)
        {
            Customer = new CustomerRepository(connectionString);
        }
        public ICustomerRepository Customer { get; private set; }
    }
}
