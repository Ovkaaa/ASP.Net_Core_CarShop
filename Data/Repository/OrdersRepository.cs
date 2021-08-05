using Shop.Data.Interfaces;
using Shop.Data.Models;
using System;

namespace Shop.Data.Repository
{
    public class OrdersRepository : IAllOrders
    {
        private readonly AppDBContent _appDBContent;
        private readonly ShopCart _shopCart;

        public OrdersRepository(AppDBContent appDBContent, ShopCart shopCart)
        {
            _appDBContent = appDBContent;
            _shopCart = shopCart;
        }

        public void CreateOrder(Order order)
        {
            order.OrderTime = DateTime.Now;
            _appDBContent.Order.Add(order);

            _appDBContent.SaveChanges();

            var items = _shopCart.ListShopItems;

            foreach (var el in items)
            {
                var orderDetail = new OrderDetail()
                {
                    CarID = el.Car.ID,
                    OrderID = order.ID,
                    Price = el.Car.Price
                };

                _appDBContent.OrderDetail.Add(orderDetail);
            }

            _appDBContent.SaveChanges();
        }
    }
}
