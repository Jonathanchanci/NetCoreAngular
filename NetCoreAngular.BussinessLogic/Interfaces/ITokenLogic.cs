using NetCoreAngular.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreAngular.BussinessLogic.Interfaces
{
    public interface ITokenLogic
    {
        User ValidateUser(string email, string password);
    }
}
