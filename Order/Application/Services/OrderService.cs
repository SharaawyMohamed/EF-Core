using Core.DTOs;
using Core.Services;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace Core.Services
{
    public class OrderService : IOrderService
    {
        private readonly IGenericRepository<Order> _orderRepository;
        private readonly IGenericRepository<Product> _productRepository;
        private readonly IGenericRepository<Invoice> _invoiceRepository;

        public OrderService(IGenericRepository<Order> orderRepository, IGenericRepository<Product> productRepository, IGenericRepository<Invoice> invoiceRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _invoiceRepository = invoiceRepository;
        }

        public async Task<OrderDto?> CreateOrder(OrderDto orderDto)
        {
            var order = new Order
            {
                CustomerId = orderDto.CustomerId,
                OrderDate = DateTime.Now,
                TotalAmount = orderDto.TotalAmount,
                OrderItems = orderDto.OrderItems.Select(oi => new OrderItem
                {
                    OrderId=orderDto.OrderId,
                    ProductId = oi.ProductId,
                    Quantity = oi.Quantity,
                    UnitPrice = oi.UnitPrice,
                    Discount = oi.Discount
                }).ToList(),
                PaymentMethod = orderDto.PaymentMethod,
                Status = "Pending"
            };
            foreach (var orderItem in order.OrderItems)
            {
                var product = await _productRepository.GetById(orderItem.ProductId);
                if (product is null || product.Stock < orderItem.Quantity)
                {
                    return null;
                }
            }
            decimal totalAmmount = 0;
            foreach (var orderItem in order.OrderItems)
            {
                var product = await _productRepository.GetById(orderItem.ProductId);
                totalAmmount += (product.Price-orderItem.Discount)*orderItem.Quantity;
                product.Stock -= orderItem.Quantity;
                await _productRepository.Update(product);
            }
            if (totalAmmount > 200)
            {
                totalAmmount -= totalAmmount * (decimal)0.10;
            }
            else if (totalAmmount > 100)
            {
                totalAmmount -= totalAmmount * (decimal)0.5;
            }
            order.TotalAmount = totalAmmount;

            Guid guid = Guid.NewGuid();
            int uniqueIntValue = guid.GetHashCode();
            order.Id = uniqueIntValue;
            await _orderRepository.AddAsync(order);

            var invoice = new Invoice()
            {
                InvoiceDate = DateTime.Now,
                TotalAmount = order.TotalAmount,
                OrderId=order.Id
            };
            await _invoiceRepository.AddAsync(invoice);

            return orderDto;
        }

        public async Task<OrderDto?> GetOrderById(int orderId)
        {
            var order = await _orderRepository.GetById(orderId);
            if (order == null)
            {
                return null;
            }

            var orderDto = new OrderDto
            {
                OrderId=orderId,
                CustomerId = order.CustomerId,
                OrderDate = order.OrderDate,
                TotalAmount = order.TotalAmount,
                OrderItems = order.OrderItems.Select(oi => new OrderItemDto
                {

                    OrderItemId = oi.Id,
                    ProductId = oi.ProductId,
                    Quantity = oi.Quantity,
                    UnitPrice = oi.UnitPrice,
                    Discount = oi.Discount
                }).ToList(),
                PaymentMethod = order.PaymentMethod,
                Status = order.Status
            };
            return orderDto;
        }

        public async Task<IEnumerable<OrderDto>>? GetAllOrders()
        {
            var orders = await _orderRepository.GetAllAsync();
            var orderDtos = orders.Select(o => new OrderDto
            {
                OrderId=o.Id,
                CustomerId = o.CustomerId,
                OrderDate = o.OrderDate,
                TotalAmount = o.TotalAmount,
                OrderItems = o.OrderItems.Select(oi => new OrderItemDto
                {
                    OrderItemId = oi.Id,
                    ProductId = oi.ProductId,
                    Quantity = oi.Quantity,
                    UnitPrice = oi.UnitPrice,
                    Discount = oi.Discount
                }).ToList(),
                PaymentMethod = o.PaymentMethod,
                Status = o.Status
            }).ToList();
            return orderDtos;
        }

        public async Task UpdateOrderStatus(int orderId, string status)
        {
            var order = await _orderRepository.GetById(orderId);
            if (order == null)
            {
                throw new Exception("Order not found");
            }
            order.Status = status;
            await _orderRepository.Update(order);
        }
    }
}
