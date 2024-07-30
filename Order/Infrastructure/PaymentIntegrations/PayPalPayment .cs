using Core.DTOs;
using Core.Models;
using Core.Services;
using PayPalCheckoutSdk.Core;
using PayPalCheckoutSdk.Orders;
using PayPalHttp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Core.Data;
using Order = Core.Models.Order;

namespace Core.PaymentIntegrations
{
    public class PayPalPayment : IPayPalPayment
    {
        private readonly PayPalHttpClient _client;
        private readonly IGenericRepository<Order> _orderRepository;
        private readonly IConfiguration _configuration;

        public PayPalPayment(IConfiguration configuration, IGenericRepository<Order> orderRepository)
        {
            _configuration = configuration;
            _orderRepository = orderRepository;

            string clientId = _configuration["PayPal:ClientId"];
            string clientSecret = _configuration["PayPal:Secret"];
            string url = _configuration["PayPal:Url"];

            var environment = new PayPalEnvironment(clientId, clientSecret, url, url);
            _client = new PayPalHttpClient(environment);
        }

        public async Task<InvoiceDto> PaymentWithPayPal(int orderId)
        {
            var order = await _orderRepository.GetById(orderId);
            if (order == null)
            {
                throw new Exception("Order not found");
            }

            decimal totalAmount = order.OrderItems.Sum(item => item.UnitPrice);

            // Apply discounts
            if (totalAmount > 200)
            {
                totalAmount -= totalAmount * (decimal)0.10;
            }
            else if (totalAmount > 100)
            {
                totalAmount -= totalAmount * (decimal)0.05;
            }

            var orderRequest = new OrderRequest()
            {
                CheckoutPaymentIntent = "CAPTURE",
                PurchaseUnits = new List<PurchaseUnitRequest>()
                {
                    new PurchaseUnitRequest()
                    {
                        AmountWithBreakdown = new AmountWithBreakdown()
                        {
                            CurrencyCode = "USD",
                            Value = totalAmount.ToString("F2") // Ensure proper formatting
                        }
                    }
                },
                ApplicationContext = new ApplicationContext()
                {
                    ReturnUrl = _configuration["PayPal:Url"],
                    CancelUrl = _configuration["PayPal:Url"]
                }
            };

            var request = new OrdersCreateRequest();
            request.Prefer("return=representation");
            request.RequestBody(orderRequest);

            try
            {
                var response = await _client.Execute(request);
                var result = response.Result<Order>();

                // Map PayPal order response to your InvoiceDto
                var invoice = new InvoiceDto
                {
                    OrderId = orderId,
                    PaymentType = result.Status,
                    TotalAmount = totalAmount
                };

                return invoice;
            }
            catch (HttpException httpEx)
            {
                // Handle HTTP-specific exceptions
                throw new Exception("PayPal payment failed", httpEx);
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                throw new Exception("An unexpected error occurred during PayPal payment", ex);
            }
        }
    }
}
