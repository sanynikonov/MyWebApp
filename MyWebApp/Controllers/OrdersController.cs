using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Business;

namespace MyWebApp.Controllers
{
    public class OrdersController : ApiController
    {
        private IOrderService orderService;

        public OrdersController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpPost]
        public async Task PostOrder([FromBody] OrderDTO order)
        {
            await orderService.Add(order);
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetAllOrders()
        {
            var orders = await orderService.GetAll();
            return Ok(orders);
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetOrder(int id)
        {
            var order = await orderService.Get(id);
            return Ok(order);
        }

        [HttpGet]
        [Route("api/orders/{id}/products")]
        public async Task<IHttpActionResult> GetAllProductsByOrderId(int id)
        {
            var order = await orderService.Get(id);
            var products = order.Products;
            return Ok(products);
        }

        [HttpPut]
        [Route("api/orders/{id}/products")]
        public async Task AddProductToOrderList(int id, [FromBody]ProductDTO product)
        {
            await orderService.AddProductToOrder(id, product);
        }
    }
}