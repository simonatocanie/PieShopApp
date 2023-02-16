

using Microsoft.AspNetCore.Mvc;
using PieShopApp.Controllers;
using PieShopApp.ViewModels;
using PieShopAppTests.Mocks;

namespace PieShopAppTests.Controllers
{
    public class PieControllerTests
    {
        [Fact]
        public void List_EmptyCategory_ShouldReturnAllPies()
        {
            //arrange
            var pieRepository = MockRepositories.GetPieRepository();
            var categoryRepository = MockRepositories.GetCategoryRepository();

            //act
            var pieController = new PieController(pieRepository.Object, categoryRepository.Object);
            var result = pieController.List("");

            //assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var pieListViewModel = Assert.IsAssignableFrom<PieListViewModel>(viewResult.ViewData.Model);
            Assert.Equal(4, pieListViewModel?.Pies?.Count());
        }
    }
}
