using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interfaces;
using Shop.Data.Models;
using Shop.ViewModels;

namespace Shop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAllCars _carRep;
        private readonly ShopCart _shopCart;

        public HomeController(IAllCars carRep, ShopCart shopCart)
        {
            _carRep = carRep;
            _shopCart = shopCart;
        }

        public ViewResult Index()
        {
            var homeCars = new HomeViewModel 
            { 
            FavCars = _carRep.GetFavCars
            };
            return View(homeCars);
        }
    }
}
