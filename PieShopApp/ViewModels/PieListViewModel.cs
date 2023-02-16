using PieShopApp.Models;

namespace PieShopApp.ViewModels
{
    public class PieListViewModel
    {
        public IEnumerable<Pie>? Pies { get; set; }
        public string? CategoryCode { get; set; } 
        public PieListViewModel(IEnumerable<Pie>? pies, string? categoryCode) {
            Pies = pies;
            CategoryCode = categoryCode;
        }
    }
}
