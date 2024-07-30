using Core.DTOs;
using Core.Services;
using Core.Services;
using Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace OrderSystem.Settings.Controllers
{
	[Authorize]
	public class OrderController : ApiBaseController
	{
		private readonly IOrderService _orderService;

		public OrderController(IOrderService orderService)
		{
			_orderService = orderService;
		}

		[HttpPost]
		public  async Task<ActionResult<OrderDto>> CreateOrder([FromBody] OrderDto orderDto)
		{
			var result = await _orderService.CreateOrder(orderDto);
			if(result is null)
			{
				return BadRequest();
			}
			return result;
		}

		[HttpGet("{orderId}")]
		public async Task<ActionResult<OrderDto>> GetOrderById(int orderId)
		{
			var order = await (_orderService.GetOrderById(orderId))!;
			if(order is null)
			{
				return NotFound();
			}
			return Ok(order);
		}

		[HttpGet]
		[Authorize(Roles = "Admin")]
		public async Task<ActionResult<IEnumerable<OrderDto>>> GetAllOrders()
		{
			var orders = await (_orderService.GetAllOrders())!;
			if(orders is null)
			{
				throw new Exception("There is no orders until now");
			}
			return Ok(orders);
		}

		[HttpPut("{orderId}/status")]
		[Authorize(Roles = "Admin")]
		public async Task<ActionResult> UpdateOrderStatus(int orderId, [FromBody] string status)
		{
			await _orderService.UpdateOrderStatus(orderId, status);
			return NoContent();
		}
	}
}
