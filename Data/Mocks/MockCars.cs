using System;
using System.Collections.Generic;
using System.Linq;
using Shop.Data.Interfaces;
using Shop.Data.Models;

namespace Shop.Data.Mocks
{
    public class MockCars : IAllCars
    {
        private readonly ICarsCategory _categoryCars = new MockCategory();
        public IEnumerable<Car> Cars
        {
            get
            {
                return new List<Car>
                {
                    new Car
                    {
                        Name = "Tesla Model S",
                        ShortDesc = "Fast car",
                        LongDesc = "Beautiful, fast and very quiet car by Tesla company",
                        Img = "/img/tesla.jpg",
                        Price = 45000,
                        IsFavourite = true,
                        Available = true,
                        Category = _categoryCars.AllCategories.First()
                    },
                    new Car
                    {
                        Name = "Ford Fiesta",
                        ShortDesc = "Quiet and calm car",
                        LongDesc = "Comfortable car for city life",
                        Img = "/img/fiesta.jpg",
                        Price = 11000,
                        IsFavourite = false,
                        Available = true,
                        Category = _categoryCars.AllCategories.Last()
                    },
                    new Car
                    {
                        Name = "BMW M3",
                        ShortDesc = "Cheeky and stylish car",
                        LongDesc = "Comfortable car for city life",
                        Img = "/img/m3.jpg",
                        Price = 65000,
                        IsFavourite = true,
                        Available = true,
                        Category = _categoryCars.AllCategories.Last()
                    },
                    new Car
                    {
                        Name = "Mercedes C Class",
                        ShortDesc = "Cozy and large car",
                        LongDesc = "Comfortable car for city life",
                        Img = "/img/mercedes.jpg",
                        Price = 40000,
                        IsFavourite = false,
                        Available = false,
                        Category = _categoryCars.AllCategories.Last()
                    },
                    new Car
                    {
                        Name = "Nissan Leaf",
                        ShortDesc = "Silent and economical car",
                        LongDesc = "Comfortable car for city life",
                        Img = "/img/nissan.jpg",
                        Price = 14000,
                        IsFavourite = true,
                        Available = true,
                        Category = _categoryCars.AllCategories.First()
                    }
                };
            }
        }
        public IEnumerable<Car> GetFavCars { get; }

        public Car GetObjectCar(int carId)
        {
            throw new NotImplementedException();
        }
    }
}
