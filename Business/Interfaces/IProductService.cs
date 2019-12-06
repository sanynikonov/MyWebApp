using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public interface IProductService
    {
        IEnumerable<ProductDTO> GetAll();

        void Add(ProductDTO product);
    }
}
