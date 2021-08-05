using System.Collections.Generic;
using Shop.Data.Interfaces;
using Shop.Data.Models;

namespace Shop.Data.Mocks
{
    public class MockCategory : ICarsCategory
    {
        public IEnumerable<Category> AllCategories
        {
            get
            {
                return new List<Category>
                {
                    new Category {CategoryName = "Electric Cars", Desc = "Modern type of transport"},
                    new Category {CategoryName = "Classic Cars", Desc = "Cars with internal combustion engine"},
                };
            }
        }
    }
}
