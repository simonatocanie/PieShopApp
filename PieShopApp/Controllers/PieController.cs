using Microsoft.AspNetCore.Mvc;
using PieShopApp.Models;
using PieShopApp.Models.Repositories.Repositories;
using PieShopApp.ViewModels;

namespace PieShopApp.Controllers
{
    public class PieController : Controller
    {
        private readonly IPieRepository pieRepository;
        private readonly ICategoryRepository categoryRepository;

        public PieController(IPieRepository pieRepository, ICategoryRepository categoryRepository)
        {
            this.pieRepository = pieRepository;
            this.categoryRepository = categoryRepository;
        }
        //public IActionResult List()
        //{
        //    return View(new PieListViewModel(pieRepository.AllPies, "All pies"));
        //}

        public IActionResult List(string category)
        {
            IEnumerable<Pie> pies;
            string? currentCategory;

            if ( string.IsNullOrEmpty(category) ){
                pies = pieRepository.AllPies.OrderBy(x => x.PieId);
                currentCategory = "All pies";
            }
            else
            {
                pies = pieRepository.AllPies.Where(x=> x.Category.CategoryName == category).OrderBy(x=> x.PieId);
                currentCategory = categoryRepository.AllCategories.FirstOrDefault(x => x.CategoryName == category)?.CategoryName; ;
            }
            return View(new PieListViewModel(pies, currentCategory));
        }

        public IActionResult Details(int pieId)
        {
            var pie = pieRepository.GetPieById(pieId);

            if (pie == null)
                return NotFound();

            return View(pie);
        }
    }
}
