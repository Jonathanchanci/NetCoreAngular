using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetCoreAngular.BussinessLogic.Interfaces;
using NetCoreAngular.UnitOfWork;

namespace NetCoreAngular.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Order")]
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrderLogic _logic;
        public OrderController(IOrderLogic logic)
        {
            _logic = logic;
        }

        [HttpGet]
        [Route("GetPaginatedOrder/{page:int}/{rows:int}")]
        public IActionResult GetPaginatedOrder(int page, int rows)
        {
            return Ok(_logic.GetPaginatedOrder(page, rows));
        }

        [HttpGet]
        [Route("GetOrderById/{orderId:int}")]
        public IActionResult GetOrderById(int orderId)
        {
            return Ok(_logic.GetOrderById(orderId));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var request = _logic.GetById(id);
            return Ok(_logic.Delete(request));
        }
    }
}