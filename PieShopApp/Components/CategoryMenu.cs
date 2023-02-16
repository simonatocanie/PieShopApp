using Microsoft.AspNetCore.Mvc;
using PieShopApp.Models.Repositories.Repositories;

namespace PieShopApp.Components
{
    public class CategoryMenu:ViewComponent
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryMenu(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public IViewComponentResult Invoke()
        {
            var categories = categoryRepository.AllCategories.OrderBy(x => x.CategoryName);
            return View(categories);
        }
    }
}
