using Core.Services;
using Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Core.DTOs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace OrderSystem.Settings.Controllers
{
    [Authorize]
    public class CustomerController : ApiBaseController
    {
        private readonly IOrderService _orderRepository;
        private readonly ICustomerService _customerRepository;

        public CustomerController(ICustomerService customerRepository, IOrderService orderRepository)
        {
            _customerRepository = customerRepository;
            _orderRepository = orderRepository;
        }

        // POST /api/customers - Create a new customer
        [HttpPost]
        public async Task<ActionResult<CustomerDto>> CreateCustomer([FromBody] CustomerDto customer)
        {
            return !await _customerRepository.CreateCustomer(customer) ? BadRequest("Addition Failed")
                : new CustomerDto()
                {
                    Email = customer.Email,
                    Name = customer.Name
                } ;
        }

        // GET /api/customers/{customerId}/orders - Get all orders for a customer
        [HttpGet("{customerId}/orders")]
        public async Task<IActionResult> GetCustomerOrders(int customerId)
        {
            var orders = await (_customerRepository.GetCustomerOrders(customerId))!;
            if (!orders.Any())
            {
                return NotFound();
            }
            return Ok(orders);
        }
    }
}
