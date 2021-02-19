using NetCoreAngular.Models;

namespace NetCoreAngular.Repositories
{
    public interface IUserRepository :IRepository<User>
    {
        User ValidateUser(string email, string password);
    }
}
