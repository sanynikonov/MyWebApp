using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Business;

namespace MyWebApp.Controllers
{
    public class ProductsController : ApiController
    {
        private IProductService productService;

        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        public IEnumerable<ProductDTO> GetAllProducts()
        {
            return productService.GetAll();
        }

        [HttpPost]
        public void PostProduct([FromBody] ProductDTO product)
        {
            productService.Add(product);
        }
    }
}
