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

        public async Task Add(ProductDTO product)
        {
            var prod = mapper.Map<Product>(product);
            await unit.ProductRepository.Add(prod);
            await unit.Save();
        }

        public async Task<IEnumerable<ProductDTO>> GetAll()
        {
            var products = await unit.ProductRepository.GetAll();
            return products.Select(product => mapper.Map<ProductDTO>(product));
        }
    }
}
