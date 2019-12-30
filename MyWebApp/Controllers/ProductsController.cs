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
    public class ProductsController : ApiController
    {
        private IProductService productService;

        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        public async Task<IEnumerable<ProductDTO>> GetAllProducts()
        {
            return await productService.GetAll();
        }

        [HttpPost]
        public async Task PostProduct([FromBody] ProductDTO product)
        {
            await productService.Add(product);
        }
    }
}
