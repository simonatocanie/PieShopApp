namespace PieShopApp.Models.Repositories.Repositories
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> AllCategories { get; }
    }
}
