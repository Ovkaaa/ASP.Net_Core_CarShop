using Shop.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Data
{
    public class DBObjects
    {
        private static Dictionary<string, Category> _category;

        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (_category == null)
                {
                    var list = new Category[]
                        {
                            new Category {CategoryName = "Electric Cars", Desc = "Modern type of transport"},
                            new Category {CategoryName = "Classic Cars", Desc = "Cars with internal combustion engine"},
                        };

                    _category = new Dictionary<string, Category>();
                    foreach (Category el in list)
                    {
                        _category.Add(el.CategoryName, el);
                    }
                }
                return _category;
            }
        }

        public static void Initial(AppDBContent content)
        {
            if (!content.Category.Any())
            {
                content.Category.AddRange(Categories.Select(c => c.Value));
            }

            if (!content.Car.Any())
            {
                content.AddRange(
                        new Car
                        {
                            Name = "Tesla Model S",
                            ShortDesc = "Fast car",
                            LongDesc = "Beautiful, fast and very quiet car by Tesla company",
                            Img = "/img/tesla.jpg",
                            Price = 45000,
                            IsFavourite = true,
                            Available = true,
                            Category = Categories["Electric Cars"]
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
                            Category = Categories["Classic Cars"]
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
                            Category = Categories["Classic Cars"]
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
                            Category = Categories["Classic Cars"]
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
                            Category = Categories["Electric Cars"]
                        }
                    );
            }

            content.SaveChanges();
        }
    }
}
