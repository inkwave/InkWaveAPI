﻿using Inkwave.Domain;

namespace Inkwave.Application.Interfaces.Repositories
{
    public interface IOrderRepository
    {
        Task<Order> CreateOrderFromCartAsync(Guid userId, Guid billingAddressId, Guid shippingAddressId, CancellationToken cancellationToken);
        Task<Order> AddOrderAsync(Guid userId, Guid billingAddressId, Guid shippingAddressId, double price, double discount, double tax, double net);
        Task<OrderLine> AddOrderLineAsync(Order order, Guid itemId, double quantity, double price, double discount, double tax);
        Task RemoveOrderAsync(Guid Id, CancellationToken cancellationToken);
        Task RemoveOrderLineAsync(Guid Id);
        Task<List<Order>> GetOrdersByUserIdAsync(Guid userId, CancellationToken cancellationToken);
        Task<Order> GetOrderByIdAsync(Guid Id);
        Task<List<OrderLine>> GetOrderLinesByOrderIdAsync(Guid orderId, CancellationToken cancellationToken);
    }
}