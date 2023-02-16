using Microsoft.EntityFrameworkCore;
using PieShopApp.Models.Context;

namespace PieShopApp.Models.Repositories.Repositories
{
    public class PieRepository : IPieRepository
    {
        private readonly PieShopDbContext dbContext;

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
    }
}
