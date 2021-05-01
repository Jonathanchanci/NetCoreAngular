using NetCoreAngular.BussinessLogic.Interfaces;
using NetCoreAngular.Models;
using NetCoreAngular.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreAngular.BussinessLogic.Implementations
{
    public class TokenLogic : ITokenLogic
    {
        private IUnitOfWork _unitOfWork;

        public TokenLogic(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;
        public User ValidateUser(string email, string password)
        {
            return _unitOfWork.User.ValidateUser(email, password);
        }
    }
}
