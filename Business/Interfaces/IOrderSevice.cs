using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public interface IOrderService
    {
        Task Add(OrderDTO order);

        Task<IEnumerable<OrderDTO>> GetAll();

        Task<OrderDTO> Get(int id);

        Task AddProductToOrder(int orderId, ProductDTO product);
    }
}
