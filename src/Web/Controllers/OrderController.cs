using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.eShopWeb.ApplicationCore.Entities;
using Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate;
using Microsoft.eShopWeb.Infrastructure.Data;
using Microsoft.eShopWeb.Web.Features.MyOrders;
using Microsoft.eShopWeb.Web.Features.OrderDetails;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Microsoft.eShopWeb.Web.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Authorize] // Controllers that mainly require Authorization still use Controller/View; other pages use Pages
    [Route("[controller]/[action]")]
    public class OrderController : Controller
    {
        private readonly IMediator _mediator;
        private DbContext _dbContext;
        
        public OrderController(IMediator mediator, CatalogContext catalogContext)
        {
            _mediator = mediator;
            _dbContext = catalogContext;
        }

        [HttpGet()]
        public async Task<IActionResult> MyOrders()
        {
            var viewModel = await _mediator.Send(new GetMyOrders(User.Identity.Name)).ConfigureAwait(true);

            return View(viewModel);
        }

        [HttpGet("{orderId}")]
        public async Task<IActionResult> Detail(int orderId)
        {
            var viewModel = await _mediator.Send(new GetOrderDetails(User.Identity.Name, orderId)).ConfigureAwait(true);

            if (viewModel == null)
            {
                return BadRequest("No such order found for this user.");
            }
     
            Console.WriteLine(_dbContext);
            var order = _dbContext.Find<Order>(orderId);

            Console.WriteLine(order);
            
            foreach (OrderItem item in order.OrderItems)
            {
                var update_quantity_item = _dbContext.Find<CatalogItem>(item.ItemOrdered.CatalogItemId);
                Console.WriteLine(item);
                update_quantity_item.Quantity -= item.Units;
                await _dbContext.SaveChangesAsync().ConfigureAwait(false);
                Console.WriteLine(update_quantity_item);
            }

            return View(viewModel);
        }
    }
}
