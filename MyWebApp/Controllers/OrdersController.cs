using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
        public void PostOrder([FromBody] OrderDTO order)
        {
            orderService.Add(order);
        }

        [HttpGet]
        public IHttpActionResult GetAllOrders()
        {
            return Ok(orderService.GetAll());
        }

        [HttpGet]
        public IHttpActionResult GetOrder(int id)
        {
            return Ok(orderService.Get(id));
        }

        [HttpGet]
        [Route("api/orders/{id}/products")]
        public IHttpActionResult GetAllProductsByOrderId(int id)
        {
            return Ok(orderService.Get(id).Products);
        }

        [HttpPut]
        [Route("api/orders/{id}/products")]
        public void AddProductToOrderList(int id, [FromBody]ProductDTO product)
        {
            orderService.AddProductToOrder(id, product);
        }
    }
}