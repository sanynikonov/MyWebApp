using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class OrderServicePlug : IOrderService
    {
        private List<OrderDTO> orders;

        public void Add(OrderDTO order)
        {
            orders.Add(order);
        }

        public OrderDTO Get(int id)
        {
            return orders.Where(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<OrderDTO> GetAll()
        {
            return orders;
        }

        public void AddProductToOrder(int orderId, ProductDTO product)
        {
            throw new NotImplementedException();
        }

        public OrderServicePlug()
        {
            var productService = new ProductServicePlug();
            orders = new List<OrderDTO>
            {
                new OrderDTO
                {
                    Id = 0,
                    Products = new List<ProductDTO>()
                    {
                        productService.Get(0),
                        productService.Get(2),
                    }
                },
                new OrderDTO
                {
                    Id = 1,
                    Products = new List<ProductDTO>()
                    {
                        productService.Get(0),
                        productService.Get(1),
                        productService.Get(2),
                        productService.Get(3),
                    }
                },
            };
        }
    }
}
