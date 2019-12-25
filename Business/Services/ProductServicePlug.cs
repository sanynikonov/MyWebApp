using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class ProductServicePlug : IProductService
    {
        private List<ProductDTO> products;

        public void Add(ProductDTO product)
        {
            products.Add(product);
        }

        public IEnumerable<ProductDTO> GetAll()
        {
            return products;
        }

        public ProductDTO Get(int id)
        {
            return products.Where(x => x.Id == id).FirstOrDefault();
        }

        public ProductServicePlug()
        {
            products = new List<ProductDTO>
            {
                new ProductDTO
                {
                    Id = 0,
                    Name = "One man",
                    Price = 1000M,
                },
                new ProductDTO
                {
                    Id = 1,
                    Name = "One soul",
                    Price = 1100M,
                },
                new ProductDTO
                {
                    Id = 2,
                    Name = "One heart",
                    Price = 900M,
                },
                new ProductDTO
                {
                    Id = 3,
                    Name = "One mission",
                    Price = 1300M,
                },
            };
        }
    }
}
