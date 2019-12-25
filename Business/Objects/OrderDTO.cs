using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public List<ProductDTO> Products { get; set; } = new List<ProductDTO>();
    }
}
