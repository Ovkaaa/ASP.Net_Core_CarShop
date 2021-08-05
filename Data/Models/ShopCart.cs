using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Data.Models
{
    public class ShopCart
    {
        public readonly AppDBContent _appDBContent;

        public ShopCart(AppDBContent appDBContent)
        {
            _appDBContent = appDBContent;
        }

        public string ShopCartID { get; set; }

        public List<ShopCartItem> ListShopItems { get; set; }

        public static ShopCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDBContent>();
            string shopCartID = session.GetString("CartID") ?? Guid.NewGuid().ToString();

            session.SetString("CartID", shopCartID);

            return new ShopCart(context) { ShopCartID = shopCartID };
        }

        public void AddToCart(Car car)
        {
            _appDBContent.ShopCartItems.Add(new ShopCartItem
            {
                ShopCartID = ShopCartID,
                Car = car,
                Price = car.Price
            });

            _appDBContent.SaveChanges();
        }

        public List<ShopCartItem> GetShopItems()
        {
            return _appDBContent.ShopCartItems.Where(c => c.ShopCartID == ShopCartID).Include(s => s.Car).ToList();
        }
    }
}
