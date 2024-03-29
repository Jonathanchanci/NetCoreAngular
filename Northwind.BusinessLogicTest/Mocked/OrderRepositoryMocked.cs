﻿using AutoFixture;
using Moq;
using NetCoreAngular.Models;
using NetCoreAngular.Repositories;
using NetCoreAngular.UnitOfWork;
using System.Collections.Generic;
using System.Linq;

namespace Northwind.BusinessLogicTest.Mocked
{
    public class OrderRepositoryMocked
    {
        private readonly List<Order> _orders;

        public OrderRepositoryMocked()
        {
            _orders = GetOrders();
        }

        private IOrderRepository GetOrderRepository()
        {
            var orderMocked = new Mock<IOrderRepository>();
            orderMocked.Setup(c => c.GetList())
                .Returns(_orders);

            return orderMocked.Object;
        }

        public IUnitOfWork GetInstance()
        {
            var mocked = new Mock<IUnitOfWork>();
            mocked.Setup(u => u.Order).Returns(GetOrderRepository());

            return mocked.Object;
        }

        public List<Order> GetOrders()
        {
            var fixture = new Fixture();
            var orders = fixture.CreateMany<Order>(50).ToList();
            for (int i = 0; i < 50; i++)
            {
                orders[i].Id = i + 1;
            }
            return orders;
        }
    }
}
