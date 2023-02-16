

using Moq;
using PieShopApp.Models.Repositories.Repositories;
using PieShopAppTests.Data;

namespace PieShopAppTests.Mocks
{
    public class MockRepositories
    {
        public static Mock<IPieRepository> GetPieRepository()
        {
            var pies = DataUtility.Pies;

            var repository = new Mock<IPieRepository>();
            repository.Setup(repo => repo.AllPies).Returns(pies);
            repository.Setup(repo => repo.PiesOfTheWeek).Returns(pies.Where(x => x.IsPieOfTheWeek));
            repository.Setup(repo => repo.GetPieById(It.IsAny<int>())).Returns(pies[0]);

            return repository;
        }
        public static Mock<ICategoryRepository> GetCategoryRepository()
        {
            var categories = DataUtility.Categories;

            var repository = new Mock<ICategoryRepository>();
            repository.Setup(repo => repo.AllCategories).Returns(categories);
            return repository;
        }
    }
}
