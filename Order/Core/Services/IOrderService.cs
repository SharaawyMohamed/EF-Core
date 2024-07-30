using Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
	public interface IOrderService
	{
		public Task<OrderDto?> CreateOrder(OrderDto orderDto);
		public Task<OrderDto?> GetOrderById(int orderId);
		public Task<IEnumerable<OrderDto>>? GetAllOrders();
		public Task UpdateOrderStatus(int orderId, string status);
	}
}
