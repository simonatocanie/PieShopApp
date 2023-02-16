using PieShopApp.Models.Context;

namespace PieShopApp.Models.Repositories.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly PieShopDbContext dbContext;

        public CategoryRepository(PieShopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<Category> AllCategories => dbContext.Categories.OrderBy(x => x.CategoryName);
    }
}
