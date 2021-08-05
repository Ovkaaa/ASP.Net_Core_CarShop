using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interfaces;
using Shop.Data.Models;
using Shop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Controllers
{
    public class CarsController : Controller
    {
        private readonly IAllCars _allCars;
        private readonly ICarsCategory _allCategories;

        public CarsController(IAllCars iAllCars, ICarsCategory iCarsCat)
        {
            _allCars = iAllCars;
            _allCategories = iCarsCat;
        }

        [Route("Cars/List")]
        [Route("Cars/List/{category}")]
        public ViewResult List(string category)
        {
            IEnumerable<Car> cars = null;
            string currCategory = string.Empty;
            if (string.Equals("electro", category, StringComparison.OrdinalIgnoreCase) || string.Equals("classic", category, StringComparison.OrdinalIgnoreCase))
            {
                if (string.Equals("electro", category, StringComparison.OrdinalIgnoreCase))
                {
                    cars = _allCars.Cars.Where(i => i.Category.CategoryName.Equals("Electric Cars")).OrderBy(i => i.ID);
                    currCategory = "Electric Cars";
                }
                else
                {
                    cars = _allCars.Cars.Where(i => i.Category.CategoryName.Equals("Classic Cars")).OrderBy(i => i.ID);
                    currCategory = "Classic Cars";
                }
            }
            else
            {
                cars = _allCars.Cars.OrderBy(i => i.ID);
            }

            var obj = new CarsListViewModel
            {
                AllCars = cars,
                CurrCategory = currCategory
            };

            ViewBag.Title = "Page with autoomobile";

            return View(obj);
        }
    }
}
