using Inkwave.Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Inkwave.Persistence.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        readonly IGenericRepository<Order> _orderRepository;
        readonly IGenericRepository<OrderLine> _orderLineRepository;
        readonly ICartRepository _cartRepository;
        readonly IGenericRepository<Item> _itemRepository;

        public OrderRepository(IGenericRepository<Order> OrderRepository, IGenericRepository<OrderLine> orderLineRepository, ICartRepository cartRepository, IGenericRepository<Item> itemRepository)
        {
            this._orderRepository = OrderRepository;
            _orderLineRepository = orderLineRepository;
            _cartRepository = cartRepository;
            _itemRepository = itemRepository;
        }

        public async Task<Order> CreateOrderFromCartAsync(Guid userId, Guid addressId, Guid paymentMethodId, bool isCashOnDelivery, CancellationToken cancellationToken)
        {
            var customerCart = await _cartRepository.GetCartByUserIdAsync(userId, cancellationToken);
            var customerCartItems = await _itemRepository.GetByIdsAsync(customerCart.Select(x => x.ItemId));
            double price = customerCartItems.Sum(x => x.Price);
            double discount = customerCartItems.Sum(x => x.Discount);
            double tax = customerCartItems.Sum(x => x.Tax);
            double net = (price - discount) + tax;
            var order = Order.Create(userId, addressId, paymentMethodId, isCashOnDelivery, price, discount, tax, net);
            customerCart.ForEach(cart =>
            {
                var item = customerCartItems.Find(x => x.Id == cart.ItemId);
                order.SetOrderLine(cart.ItemId, cart.Quantity, item.Price, item.Discount, item.Tax);
            });
            await _orderRepository.AddAsync(order);
            await _orderLineRepository.AddRangeAsync(order.GetOrderLines());
            return order;
        }
        public Task<Order> AddOrderAsync(Guid userId, Guid addressId, Guid paymentMethodId, bool isCashOnDelivery, double price, double discount, double tax, double net)
        {
            var order = Order.Create(userId, addressId, paymentMethodId, isCashOnDelivery, price, discount, tax, net);
            _orderRepository.AddAsync(order);
            return Task.FromResult(order);
        }
        public Task<OrderLine> AddOrderLineAsync(Order order, Guid itemId, double quantity, double price, double discount, double tax)
        {
            var orderLine = order.SetOrderLine(itemId, quantity, price, discount, tax);
            _orderLineRepository.AddAsync(orderLine);
            return Task.FromResult(orderLine);
        }


        public async Task<List<Order>> GetOrdersByUserIdAsync(Guid userId, CancellationToken cancellationToken)
        {
            return await _orderRepository.Entities.Where(x => x.CustomerId == userId).ToListAsync(cancellationToken);
        }
        public async Task<Order> GetOrderByIdAsync(Guid userId)
        {
            return await _orderRepository.GetByIdAsync(userId);
        }
        public async Task<List<OrderLine>> GetOrderLinesByOrderIdAsync(Guid orderId, CancellationToken cancellationToken)
        {
            return await _orderLineRepository.Entities.Where(x => x.OrderId == orderId).ToListAsync(cancellationToken);
        }
        public async Task RemoveOrderAsync(Guid Id, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetByIdAsync(Id);
            if (order != null)
            {
                var orderLine = await GetOrderLinesByOrderIdAsync(Id, cancellationToken);
                orderLine.ForEach(async x => await RemoveOrderLineAsync(x.Id));
                await _orderRepository.DeleteAsync(order);
            }
        }
        public async Task RemoveOrderLineAsync(Guid Id)
        {
            var orderLine = await _orderLineRepository.GetByIdAsync(Id);
            if (orderLine != null)
                await _orderLineRepository.DeleteAsync(orderLine);
        }


    }
}
