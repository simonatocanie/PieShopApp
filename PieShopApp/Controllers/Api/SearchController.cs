using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PieShopApp.Models;
using PieShopApp.Models.Repositories.Repositories;

namespace PieShopApp.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly IPieRepository pieRepository;

        public SearchController(IPieRepository pieRepository)
        {
            this.pieRepository = pieRepository;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(pieRepository.AllPies);
        }


        [HttpGet("{pieId}")]
        public IActionResult GetById(int pieId)
        {
            var pie = pieRepository.AllPies.FirstOrDefault(x => x.PieId == pieId);

            if (pie == null)
                return NotFound();

            return Ok(pie);
        }

        [HttpPost]
        public JsonResult SearchPies([FromBody] string searchQuery)
        {
            PieRepository.searchQuerySet = searchQuery;
            IEnumerable<Pie> pies = new List<Pie>();

            if (!string.IsNullOrEmpty(searchQuery))
            {
                pies = pieRepository.SearchPies();
            }
            else
            {
                pies = pieRepository.AllPies;
            }

            return new JsonResult(pies);
        }
    }
}
