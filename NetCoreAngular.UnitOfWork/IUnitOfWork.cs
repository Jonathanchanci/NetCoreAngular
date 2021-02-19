﻿using NetCoreAngular.Repositories;

namespace NetCoreAngular.UnitOfWork
{
    public interface IUnitOfWork
    {
        ICustomerRepository Customer { get; }
        IUserRepository User { get; }
    }
}
