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

        public void Add(OrderDTO order)
        {
            var orderEntity = mapper.Map<Order>(order);
            orderEntity.Products = order.Products.Select(product => mapper.Map<Product>(product)).ToList();
            unit.OrderRepository.Add(orderEntity);
            unit.Save();
        }

        public void AddProductToOrder(int orderId, ProductDTO product)
        {
            var order = unit.OrderRepository.Get(orderId);
            var productEntity = mapper.Map<Product>(product);
            order.Products.Add(productEntity);
            unit.OrderRepository.Update(order);
            unit.Save();
        }

        public OrderDTO Get(int id)
        {
            var order = unit.OrderRepository.Get(id);
            var orderDTO = mapper.Map<OrderDTO>(order);
            orderDTO.Products = order.Products.Select(product => mapper.Map<ProductDTO>(product)).ToList();
            return orderDTO;
        }

        public IEnumerable<OrderDTO> GetAll()
        {
            var orders = unit.OrderRepository.GetAll();
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
