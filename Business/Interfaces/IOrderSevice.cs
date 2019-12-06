using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public interface IOrderService
    {
        void Add(OrderDTO order);

        IEnumerable<OrderDTO> GetAll();

        OrderDTO Get(int id);
    }
}
