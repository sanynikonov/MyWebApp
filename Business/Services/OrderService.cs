using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Business
{
    public class OrderService : IOrderService
    {
        private IUnitOfWork unit;
        private IMapper mapper;

        public OrderService(IUnitOfWork unit, IMapper mapper)
        {
            this.unit = unit;
            this.mapper = mapper;
        }

        public async Task Add(OrderDTO order)
        {
            var orderEntity = mapper.Map<Order>(order);
            orderEntity.Products = order.Products.Select(product => mapper.Map<Product>(product)).ToList();
            await unit.OrderRepository.Add(orderEntity);
            await unit.Save();
        }

        public async Task AddProductToOrder(int orderId, ProductDTO product)
        {
            var order = await unit.OrderRepository.Get(orderId);
            var productEntity = mapper.Map<Product>(product);
            order.Products.Add(productEntity);
            await unit.OrderRepository.Update(order);
            await unit.Save();
        }

        public async Task<OrderDTO> Get(int id)
        {
            var order = await unit.OrderRepository.Get(id);
            var orderDTO = mapper.Map<OrderDTO>(order);
            orderDTO.Products = order.Products.Select(product => mapper.Map<ProductDTO>(product)).ToList();
            return orderDTO;
        }

        public async Task<IEnumerable<OrderDTO>> GetAll()
        {
            var orders = await unit.OrderRepository.GetAll();
            var ordersDTO = orders.Select(order => 
            {
                var orderDTO = mapper.Map<OrderDTO>(order);
                orderDTO.Products = order.Products.Select(product => mapper.Map<ProductDTO>(product)).ToList();
                return orderDTO;
            });
            return ordersDTO;
        }
    }
}
