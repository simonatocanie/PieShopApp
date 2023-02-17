using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PieShopApp.Models.Context;

namespace PieShopApp.Models.Repositories.Repositories
{
    public class PieRepository : IPieRepository
    {
        private readonly PieShopDbContext dbContext;
        public static string? searchQuerySet;
        public PieRepository(PieShopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IEnumerable<Pie> AllPies
        {
            get
            {
                return dbContext.Pies.Include(x => x.Category);
            }
        }

        public IEnumerable<Pie> PiesOfTheWeek
        {
            get
            {
                return dbContext.Pies.Include(x => x.Category).Where(x => x.IsPieOfTheWeek);
            }
        }

        public Pie? GetPieById(int pieId)
        {
            return dbContext.Pies.FirstOrDefault(x=>x.PieId == pieId);
        }

        [HttpPost]
        public IEnumerable<Pie> SearchPies()
        {
            if (string.IsNullOrEmpty(searchQuerySet))
            {
                return AllPies;
            }
            return AllPies.Where(x => x.Name.ToLower().Contains(searchQuerySet.ToLower()));
        }

    }
}
