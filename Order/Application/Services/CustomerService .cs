using Core.DTOs;
using Core.Services;
using Core.Models;


namespace Core.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IGenericRepository<Customer> _customerRepository;
        private readonly IGenericRepository<Order> _orderRepository;

        public CustomerService(IGenericRepository<Customer> customerRepository, IGenericRepository<Order> orderRepository)
        {
            _customerRepository = customerRepository;
            _orderRepository = orderRepository;
        }

        public async Task<bool> CreateCustomer(CustomerDto customerDto)
        {
            var customer = new Customer
            {
                Name = customerDto.Name,
                Email = customerDto.Email
            };
           return await _customerRepository.AddAsync(customer);
        }

        public async Task<IEnumerable<OrderDto>>? GetCustomerOrders(int customerId)
        {
            var orders = (await _orderRepository.GetAllAsync()).Where(o => o.CustomerId == customerId);
            //maniul mapping
            var orderDtos = orders.Select(o => new OrderDto
            {
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
    }
}
