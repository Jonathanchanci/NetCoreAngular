using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetCoreAngular.UnitOfWork;

namespace NetCoreAngular.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Order")]
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrderController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("GetPaginatedOrder/{page:int}/{rows:int}")]
        public IActionResult GetPaginatedOrder(int page, int rows)
        {
            return Ok(_unitOfWork.Order.getPaginatedOrder(page, rows));
        }
    }
}