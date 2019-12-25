using AutoMapper;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class ProductService : IProductService
    {
        private IUnitOfWork unit;
        protected readonly IMapper mapper;

        public ProductService(IUnitOfWork unit, IMapper mapper)
        {
            this.unit = unit;
            this.mapper = mapper;
        }

        public void Add(ProductDTO product)
        {
            var prod = mapper.Map<Product>(product);
            unit.ProductRepository.Add(prod);
            unit.Save();
        }

        public IEnumerable<ProductDTO> GetAll()
        {
            var products = unit.ProductRepository.GetAll();
            return products.Select(product => mapper.Map<ProductDTO>(product));
        }
    }
}
