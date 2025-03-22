using AutoMapper;
using Warehouse.Common.DTOs;
using Warehouse.Data.Models;
using Warehouse.Interfaces.IRepositories;
using Warehouse.Interfaces.IServices;

namespace Warehouse.Service.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DTOOrder>> GetAllOrdersAsync()
        {
            var orders = await _orderRepository.GetAllOrdersAsync();
            return _mapper.Map<IEnumerable<DTOOrder>>(orders);
        }

        public async Task<DTOOrder?> GetOrderByIdAsync(int id)
        {
            var order = await _orderRepository.GetOrderByIdAsync(id);
            return _mapper.Map<DTOOrder>(order);
        }

        public async Task AddOrderAsync(DTOOrder orderDTO)
        {
            var orderEntity = _mapper.Map<Orders>(orderDTO);  // Conversione DTO → Entity

            // Ottieni il prodotto associato all'ordine
            var product = await _orderRepository.GetProductByIdAsync(orderDTO.ProductID);

            if (product == null)
            {
                throw new Exception("Product not found"); // Oppure un errore più gestibile
            }

            if (product.Quantity < orderDTO.Quantity)
            {
                throw new Exception("Not enough stock available");
            }

            // Scala la quantità disponibile del prodotto 
            product.Quantity -= orderDTO.Quantity;

            // Salva ordine e aggiorna prodotto
            await _orderRepository.AddOrderAsync(orderEntity);
            await _orderRepository.UpdateProductAsync(product);
        }


        public async Task UpdateOrderAsync(DTOOrder orderDTO)
        {
            var existingOrder = await _orderRepository.GetOrderByIdAsync(orderDTO.OrderID);
            if (existingOrder == null)
            {
                throw new Exception("Order not found");
            }

            var product = await _orderRepository.GetProductByIdAsync(orderDTO.ProductID);
            if (product == null)
            {
                throw new Exception("Product not found");
            }

            // Calcola la differenza di quantità
            int quantityDifference = orderDTO.Quantity - existingOrder.Quantity;

            if (product.Quantity < quantityDifference)
            {
                throw new Exception("Not enough stock available to update the order");
            }

            // Aggiorna la quantità disponibile
            product.Quantity -= quantityDifference;

            // Aggiorna l'ordine
            var orderEntity = _mapper.Map(orderDTO, existingOrder);
            await _orderRepository.UpdateOrderAsync(orderEntity);
            await _orderRepository.UpdateProductAsync(product);
        }


        public async Task DeleteOrderAsync(int id)
        {
            await _orderRepository.DeleteOrderAsync(id);
        }
    }
}
