﻿using System.Reflection.Metadata.Ecma335;
using PieShopApp.Models.Repositories.Repositories;

namespace PieShopApp.Models.Repositories.MockRepository
{
    public class MockCategoryRepository : ICategoryRepository
    {
        public IEnumerable<Category> AllCategories => new List<Category>
        {
            new Category{ CategoryId=1, CategoryName= "Fruit pies", Description="All-fruity pies"},
            new Category{ CategoryId=2, CategoryName= "Cheese cakes", Description="Cheese all the way"},
            new Category{ CategoryId=3, CategoryName= "Seasonal pies", Description="Get in the mood for a seasonal pie"}
        };
    }
}
