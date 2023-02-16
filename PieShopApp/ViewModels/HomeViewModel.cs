using PieShopApp.Models;

namespace PieShopApp.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Pie> PiesOfTheWeek { get; set; }
        public HomeViewModel(IEnumerable<Pie> pies)
        {
            PiesOfTheWeek = pies;
        }
    }
}
